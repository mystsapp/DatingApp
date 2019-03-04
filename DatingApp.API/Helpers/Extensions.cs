using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers {
    public static class Extensions {
        public static void AddApplicationError (this HttpResponse response, string meessage) {
            response.Headers.Add ("Application-Error", meessage);
            response.Headers.Add ("Access-Control-Expose-Handlers", "Application-Error");
            response.Headers.Add ("Access-Control-Allow-Origin","*");
        }
    }
}