//using Newtonsoft.Json;
//using WasiteeModels.DataModels;

//namespace WasiteeApp.Utilites
//{
//    public class CookiesHelper: ICookieHelper
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public CookiesHelper(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }
//        public BusinessUserModel  ReadUserModelFromCookie()
//        {
//            BusinessUserModel userModel = new BusinessUserModel();
         
//            HttpContext context = _httpContextAccessor.HttpContext;

//            // Get the cookie from the request cookies
//            string cookieValue = context.Request.Cookies["UserCookies"];
//            if (string.IsNullOrEmpty(cookieValue))
//            {
               
//                return userModel;
//            }

           
         
//            try
//            {
//                userModel = JsonConvert.DeserializeObject<BusinessUserModel>(cookieValue);
            
            
//            }
//            catch (JsonException ex)
//            {
                
//            }
//            return userModel;
//        }
//        public void ClearCookies()
//        {
//            HttpContext context = _httpContextAccessor.HttpContext;
//            foreach (var cookie in context.Request.Cookies.Keys)
//            {
//                context.Response.Cookies.Delete(cookie);
//            }
//        }
//    }
//}
