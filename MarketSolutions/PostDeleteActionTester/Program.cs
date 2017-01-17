using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostDeleteActionTester
{
    class Program
    {
        private static Uri _serviceUri = new Uri("http://localhost:57098/Production");

        static void Main(string[] args)
        {
            RunPostOperation();
        }

        private static void RunPostOperation()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _serviceUri);
            requestMessage.Headers.ExpectContinue = false;
            ProductionViewModel viewModel = new ProductionViewModel()
            {
                ProductName = "Gears of War",
                Discontinued = false,
                UnitPrice = 59.99m,
                ProductCategoryId = 1,
                ProductCategoryName = "PS4 Games",
                ProductDescription = "SF V",
                Quantity = 1000
            };

            string jsonInput = JsonConvert.SerializeObject(viewModel);
            requestMessage.Content = new StringContent(jsonInput, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 10, 0);
            Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);

            HttpResponseMessage httpResponse = httpRequest.Result;
            HttpStatusCode statusCode = httpResponse.StatusCode;
            HttpContent responseContent = httpResponse.Content;
            if (responseContent != null)
            {
                Task<string> stringContentsTask = responseContent.ReadAsStringAsync();
                String stringContents = stringContentsTask.Result;
                Console.WriteLine("Results from service: " + stringContents);
            }

            Console.ReadKey();
        }
    }
}
