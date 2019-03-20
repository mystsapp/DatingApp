using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DatingApp.API.Helpers {
    public static class Extensions {
        public static void AddApplicationError (this HttpResponse response, string meessage) {
            response.Headers.Add ("Application-Error", meessage);
            response.Headers.Add ("Access-Control-Expose-Handlers", "Application-Error");
            response.Headers.Add ("Access-Control-Allow-Origin","*");
        }

        public static void AddPagination (this HttpResponse response, 
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            // var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            // var camelCaseFormatter = new JsonSerializerSettings();
            // camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // response.Headers.Add("Pagination", 
            //     JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            // response.Headers.Add ("Access-Control-Expose-Handlers", "Pagination");
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", 
                JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
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