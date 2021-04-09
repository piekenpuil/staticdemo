using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace U2U.API
{
    public static class UserInfo
    {
        [FunctionName("UserInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            var header=req.Headers["x-ms-client-principal"].ToString();
            var bytes = System.Convert.FromBase64String(header);
            var info = System.Text.Encoding.UTF8.GetString(bytes);
            
            

            return new OkObjectResult(info);
        }
    }
}
