namespace Social_Media_Apis.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiErrorResponse(int code,string? message=null)
        {
            this.StatusCode = code;
            this.Message = message??GetErrorMessage(StatusCode);
            
        }
        private string GetErrorMessage(int statusCode)
        {
            switch(statusCode)
            {
                case 400:
                    return "BadRequest";
                case 401:
                    return "UnAuthorized";
                case 404:
                    return "NotFound";
                case 500:
                    return "Internal Server Error";
                default:
                    return string.Empty;


            }
        }
    }
}
