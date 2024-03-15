using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EDB.BackofficeUI.Handlers
{
    public class DefaultClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultClient(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            httpClient.BaseAddress = new Uri("http://localhost:5210");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest requsetData)
        {
            var json = JsonConvert.SerializeObject(requsetData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(responseJson);

            return result;
        }

        public async Task<dynamic> PostAsync<TRequest>(string endpoint, TRequest requsetData)
        {
            var json = JsonConvert.SerializeObject(requsetData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseJson);

            return result;
        }
    }
}
