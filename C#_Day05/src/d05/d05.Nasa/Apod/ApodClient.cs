using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace s21_d05_Nasa
{
public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private HttpClient _httpClient;

        public ApodClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }

        public async Task<MediaOfToday[]> GetAsync(int input)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            var request = $"{_requestTemplate}" +
                          $"&start_date={DateTime.Now.AddDays(-input+1).ToString("yyyy-MM-dd", cultureInfo)}" +
                          $"&end_date={DateTime.Now.ToString("yyyy-MM-dd", cultureInfo)}";
            var response = await _httpClient.GetAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            MediaOfToday[] responseMediaOfToday;
            try
            {
                responseMediaOfToday = JsonSerializer.Deserialize<MediaOfToday[]>(responseString);
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"GET{Environment.NewLine}" +
                    $"{request} returned Forbidden:{Environment.NewLine}" +
                    responseString);
                return Array.Empty<MediaOfToday>();
            }
            return responseMediaOfToday;
        }
    }
}