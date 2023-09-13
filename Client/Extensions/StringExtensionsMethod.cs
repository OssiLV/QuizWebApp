namespace QuizWebApp.Client.Extensions
{
    public static class StringExtensionsMethod
    {
        public static string ConvertToShort( this string value, int lastIndex )
        {
            if(value.Length > lastIndex)
            {
                return value[..lastIndex] + "...";
            }

            return value;
        }

        public static string GetFirstLetter( this string value )
        {
            return value.Trim().FirstOrDefault().ToString();
        }
    }
}
