using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers {
    public static class Extensions {
        public static void AddApplicationError (this HttpResponse response, string meessage) {
            response.Headers.Add ("Application-Error", meessage);
            response.Headers.Add ("Access-Control-Expose-Handlers", "Application-Error");
            response.Headers.Add ("Access-Control-Allow-Origin","*");
        }

        public static int CalculateAge (this DateTime theDateTim)
        {
            var age = DateTime.Today.Year - theDateTim.Year;

            if(theDateTim.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}