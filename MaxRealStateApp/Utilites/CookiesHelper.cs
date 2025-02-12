using MaxModels;
using Newtonsoft.Json;


namespace MaxRealStateApp.Utilites
{
    public class CookiesHelper : ICookieHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookiesHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public SignUpModel ReadUserModelFromCookie()
        {
            SignUpModel userModel = new SignUpModel();

            HttpContext context = _httpContextAccessor.HttpContext;

            // Get the cookie from the request cookies
            string cookieValue = context.Request.Cookies["UserCookies"];
            if (string.IsNullOrEmpty(cookieValue))
            {

                return userModel;
            }



            try
            {
                userModel = JsonConvert.DeserializeObject<SignUpModel>(cookieValue);


            }
            catch (JsonException ex)
            {

            }
            return userModel;
        }
        public void ClearCookies()
        {
            HttpContext context = _httpContextAccessor.HttpContext;
            foreach (var cookie in context.Request.Cookies.Keys)
            {
                context.Response.Cookies.Delete(cookie);
            }
        }
    }
}
