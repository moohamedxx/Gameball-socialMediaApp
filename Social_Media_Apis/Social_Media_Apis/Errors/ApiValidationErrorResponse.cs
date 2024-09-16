namespace Social_Media_Apis.Errors
{
    public class ApiValidationErrorResponse:ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse(IEnumerable<string> errors):base(400)
        {
            this.Errors = errors;
        }
    }
}
