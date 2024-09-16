namespace Social_Media_Apis.Errors
{
    public class ApiExceptionResponse:ApiErrorResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int code , string? message=null , string? details=null):base(code,message)
        {
            this.Details = details;
            
        }
    }
}
