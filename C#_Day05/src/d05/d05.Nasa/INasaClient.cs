using System;
using System.Globalization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace s21_d05_Nasa
{
    public interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }

    public class DateNasaClient : INasaClient<DateTime, Task<string>>
    {
        private readonly string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private readonly HttpClient _httpClient;

        public DateNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }

        public Task<string> GetAsync(DateTime date)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            var request = $"{_requestTemplate}&date={date.ToString("yyyy-MM-dd", cultureInfo)}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync();
        }
    }

    public class RandomNasaClient : INasaClient<int, Task<string>>
    {
        private readonly string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private readonly HttpClient _httpClient;

        public RandomNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }

        public Task<string> GetAsync(int count)
        {
            var request = $"{_requestTemplate}&count={count.ToString()}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync();
        }
    }

    public class StringNasaClient : INasaClient<string, string>
    {
        private readonly string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private readonly HttpClient _httpClient;

        public StringNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }

        public string GetAsync(string date)
        {
            var request = $"{_requestTemplate}&date={date}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }
}