using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuizWebApp.Server.Data.Entities;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizWebApp.Server.Services.UserService.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = configuration;
            _mapper = mapper;
        }


        public bool IsValidEmail( string email )
        {
            var trimmedEmail = email.Trim();

            if(trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }


        public SecurityToken GenerateJwtToken( User user, IList<string> userRole, DateTime tokenExpiryTimeStamp )
        {
            /* Generating JWT Token */
            /*var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(tokenExpiry);*/
            var tokenKey = Encoding.ASCII.GetBytes(_config["JWT:SecurityKey"]);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach(string role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claimsIdentity = new ClaimsIdentity(authClaims);
            var signingCreadentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                );
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCreadentials
            };

            var securityToken = new JwtSecurityTokenHandler().CreateToken(securityTokenDescriptor);


            return securityToken;
            /* Returning the User Session object */
            /* var userSession = new UserSession
             {
                 UserName = userAccount.UserName,
                 Role = userAccount.Role,
                 Token = token,
                 ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
             };

             return userSession;*/
        }

        public async Task<ResponseObjectDto<UserResponse>> LoginAsync( LoginRequest loginRequest )
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginRequest.UserNameOrEmail) ?? await _userManager.FindByNameAsync(loginRequest.UserNameOrEmail);

                // if user none signup before
                if(user is null)
                    return new ResponseObjectDto<UserResponse>(StatusCodes.Status404NotFound, "This Email or UserName has not exist!", null);

                if(!await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                    return new ResponseObjectDto<UserResponse>(StatusCodes.Status404NotFound, "Incorrect Password!", null);

                if(user is not null)
                {
                    var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(20);
                    var userRoles = await _userManager.GetRolesAsync(user);

                    // Genrate Token
                    var jwtToken = GenerateJwtToken(user, userRoles, tokenExpiryTimeStamp);
                    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                    UserResponse responseUser = _mapper.Map<UserResponse>(user);
                    responseUser.Token = accessToken;
                    responseUser.ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds;
                    foreach(string role in userRoles)
                    {
                        responseUser.Role = role;
                    }
                    return new ResponseObjectDto<UserResponse>(StatusCodes.Status200OK, "Login Success", responseUser);
                }

                return new ResponseObjectDto<UserResponse>(StatusCodes.Status500InternalServerError, "There's somthings wrong", null);
            }
            catch(Exception ex)
            {

                return new ResponseObjectDto<UserResponse>(StatusCodes.Status500InternalServerError, ex.Message, null);
            }

        }

        public async Task<ResponseObjectDto<object>> SignUpAsync( RegisterRequest registerRequest )
        {
            // Check Email
            var userEmailExist = await _userManager.FindByEmailAsync(registerRequest.Email);
            if(userEmailExist is not null) return new ResponseObjectDto<object>(StatusCodes.Status403Forbidden, "Email has already existed!", null);

            // Check UserName
            var userNameExist = await _userManager.FindByNameAsync(registerRequest.UserName);
            if(userNameExist is not null) return new ResponseObjectDto<object>(StatusCodes.Status403Forbidden, "UserName has already existed", null);

            // Create user
            User user = _mapper.Map<User>(registerRequest);

            if(await _roleManager.RoleExistsAsync(registerRequest.Role))
            {
                var result = await _userManager.CreateAsync(user, registerRequest.Password);

                if(result.Errors.Any())
                {
                    return new ResponseObjectDto<object>(StatusCodes.Status500InternalServerError, "User fail to create", null);
                }

                // Assign role for user
                await _userManager.AddToRoleAsync(user, registerRequest.Role);

                return new ResponseObjectDto<object>(StatusCodes.Status201Created, "SignUp successfully", null);
            }
            else
            {
                return new ResponseObjectDto<object>(StatusCodes.Status500InternalServerError, "This role doesnot exist", null);
            }
        }


    }
}
