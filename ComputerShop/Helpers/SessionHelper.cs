using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ComputerShop.Helpers
{
    public static class SessionHelper
    {
        public static void WriteToSession(ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T ReadFromSession<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
