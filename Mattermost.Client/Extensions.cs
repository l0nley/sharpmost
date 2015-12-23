using Newtonsoft.Json;

namespace Mattermost.Client
{
    public static class Extensions
    {
        public static string ToJson(this object @object)
        {
            return JsonConvert.SerializeObject(@object);
        }

        public static T FromString<T>(this string @string)
        {
            return JsonConvert.DeserializeObject<T>(@string);
        }
    }
}