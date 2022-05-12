namespace DeleteAfter.Helpers
{
    public class Helper : IHelper
    {

        private readonly IHttpContextAccessor _ihttpContext;
        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _ihttpContext = httpContextAccessor;
        }

        public string GetAccessToken()
        {
            var token = _ihttpContext.HttpContext.Request.Headers["Authorization"];
            return token;
        }
    }
}
