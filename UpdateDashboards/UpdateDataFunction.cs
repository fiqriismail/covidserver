using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace UpdateDashboards
{
    public static class UpdateDataFunction
    {
        // This function will execute every 30 mins 
        [FunctionName("UpdateDataFunction")]
        public static async Task Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var apiEndPoint = Environment.GetEnvironmentVariable("ServiceApi");

            log.LogInformation($"Calling api {apiEndPoint}");

            try
            {
                using var client = new HttpClient();

                var response = await client.GetAsync(apiEndPoint);

                if (response.IsSuccessStatusCode)
                {
                    log.LogInformation("API executed successfully at {InfoTime}", DateTime.UtcNow);
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    log.LogError("{ErrorMessage} at {ErrorTime}", message, DateTime.UtcNow);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error at {ErrorTime}", DateTime.Now);
            }



        }
    }
}
