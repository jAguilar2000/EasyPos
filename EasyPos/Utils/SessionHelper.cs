using System.Text.Json;

namespace EasyPos.Utils
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("UserName");
        }
        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("UserId");
        }
        public string GetUser()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("User");
        }

        public void SetListMenu<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            _httpContextAccessor.HttpContext.Session.SetString(key, serializedValue);
        }
        public T GetListMenu<T>(string key)
        {
            var serializedValue = _httpContextAccessor.HttpContext.Session.GetString(key);
            return serializedValue == null ? default : JsonSerializer.Deserialize<T>(serializedValue);
        }
    }
}
