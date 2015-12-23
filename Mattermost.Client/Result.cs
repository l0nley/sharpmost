using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mattermost.Client
{
    public class Result<T>
    {
        public static async Task<Result<T>> CreateResult(HttpResponseMessage response, Func<string, T> converter)
        {
            return new Result<T>
            {
                RequestId = response.Headers.GetValues(Constants.HEADER_REQUEST_ID).FirstOrDefault(),
                Etag = response.Headers.GetValues(Constants.HEADER_ETAG_SERVER).FirstOrDefault(),
                Data = converter(await response.Content.ReadAsStringAsync())
            };
        }

        public string RequestId { get; set; }
        public string Etag { get; set; }
        public T Data { get; set; }
    }
}
