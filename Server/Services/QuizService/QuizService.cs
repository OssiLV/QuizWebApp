﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizWebApp.Server.Data.Context;
using QuizWebApp.Server.Data.Entities;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server.Services.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly QuizAppDbContext _quizAppDbContext;
        private readonly IMapper _mapper;

        public QuizService( QuizAppDbContext quizAppDbContext, IMapper mapper )
        {
            _quizAppDbContext = quizAppDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseObjectDto<object>> CreateQuizAsync( QuizCreateRequest quizCreateRequest )
        {
            try
            {
                await _quizAppDbContext.Quizzes.AddAsync(_mapper.Map<Quiz>(quizCreateRequest));
                await _quizAppDbContext.Questions.AddRangeAsync(_mapper.Map<List<Question>>(quizCreateRequest.questionCreateRequests));
                await _quizAppDbContext.SaveChangesAsync();
                return new ResponseObjectDto<object>(StatusCodes.Status201Created, "Created Quiz and Question", null);
            }
            catch(Exception ex)
            {
                return new ResponseObjectDto<object>(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        public async Task<ResponseObjectDto<List<QuizResponse>>> GetQuizAsync( Guid id, int item )
        {
            try
            {
                /* var quizzes = _quizAppDbContext.Quizzes.Where(x => x.UserId == id).ToArray();*/
                var quizzes = await (from quiz in _quizAppDbContext.Quizzes
                                     where quiz.UserId == id
                                     orderby quiz.CreatedAt descending
                                     select _mapper.Map<QuizResponse>(quiz))
                                     .Take(item)
                                     .ToListAsync();

                if(quizzes.Count < 0)
                    return new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status200OK, "Empty!", null);

                return new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status200OK, $"Successfully to get {quizzes.Count} Quizzes ", quizzes);
            }
            catch(Exception ex)
            {
                var errorResponse = new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status500InternalServerError, ex.Message, null);
                return await Task.FromResult(errorResponse);
            }
        }
        public async Task<ResponseObjectDto<List<QuizResponse>>> GetQuizAsync( Guid id )
        {
            try
            {
                /* var quizzes = _quizAppDbContext.Quizzes.Where(x => x.UserId == id).ToArray();*/
                /*var quizzes = await (from quiz in _quizAppDbContext.Quizzes
                                     where quiz.UserId == id
                                     select _mapper.Map<QuizResponse>(quiz)
                                     ).OrderByDescending(x => _mapper.Map<QuizResponse>(x)).ToListAsync();*/

                /*var quizzes = await (from quiz in _quizAppDbContext.Quizzes
                                     where quiz.UserId == id
                                     select _mapper.Map<QuizResponse>(quiz)
                     )
                     .AsEnumerable() // Perform client-side evaluation
                     .OrderByDescending(x => _mapper.Map<QuizResponse>(x))
                     .ToListAsync();*/
                var quizzes = await (from quiz in _quizAppDbContext.Quizzes
                                     where quiz.UserId == id
                                     orderby quiz.CreatedAt descending
                                     select _mapper.Map<QuizResponse>(quiz))
                                     .ToListAsync();
                if(quizzes.Count < 0)
                    return new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status200OK, "Empty!", null);

                return new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status200OK, $"Successfully to get {quizzes.Count} Quizzes ", quizzes);
            }
            catch(Exception ex)
            {
                var errorResponse = new ResponseObjectDto<List<QuizResponse>>(StatusCodes.Status500InternalServerError, ex.Message, null);
                return await Task.FromResult(errorResponse);
            }
        }

        /*async Task<ResponseObjectDto> IQuizService.DeleteQuizAsync( Guid Id )
        {
            try
            {
                var currentQuiz = await _quizAppDbContext.Quizzes.FindAsync(Id);
                if(currentQuiz is null)
                    return new ResponseObjectDto(StatusCodes.Status404NotFound, $"Cannot find Quiz with this Id: {Id}");

                _quizAppDbContext.Quizzes.Remove(currentQuiz);

                await _quizAppDbContext.SaveChangesAsync();

                return new ResponseObjectDto(StatusCodes.Status200OK, $"Deleted Quiz with this Id: {Id}");
            }
            catch(Exception ex)
            {
                return new ResponseObjectDto(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }*/

    }
}
