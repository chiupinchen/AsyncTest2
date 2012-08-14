using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AsyncTest2.Handler
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : HttpTaskAsyncHandler
    {


        public override async Task ProcessRequestAsync(HttpContext context)
        {
            using (var client = new HttpClient())
            {
                var twitter = await client.GetStringAsync("http://twitter.com");
                context.Response.Write(twitter);

                var flushTask = context.Response.FlushAsync();
                var bingTask = client.GetStringAsync("http://bing.com");

                await Task.WhenAll(flushTask, bingTask);

                context.Response.Write(bingTask.Result);
            }
        }
    }

    public static class HttpResponseExtensions
    {
        public static Task FlushAsync(this HttpResponse response)
        {
            if (response.SupportsAsyncFlush)
            {
                return Task.Factory.FromAsync(response.BeginFlush, response.EndFlush, null);
            }

            response.Flush();
            return Task.FromResult(0);
        }
    }
}