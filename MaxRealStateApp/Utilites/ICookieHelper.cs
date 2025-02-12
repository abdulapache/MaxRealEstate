using MaxModels;


namespace MaxRealStateApp.Utilites
{
    public interface ICookieHelper
    {
        SignUpModel ReadUserModelFromCookie();
        void ClearCookies();
    }
}
