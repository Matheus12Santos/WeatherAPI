using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class MainService
    {
        private HttpClient _httpClient;
        private string apiKey = "";
        private WeatherResponse weatherResponse;
        private JsonSerializerOptions jsonSerializerOptions;

        public MainService() 
        {
            _httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<WeatherResponse> GetWeatherByCity(string cityName)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse, jsonSerializerOptions);
                    if (weatherResponse == null)
                    {
                        Console.WriteLine("Erro na deserialização da resposta da API: o objeto retornado é nulo.");
                    }
                }
                else
                {
                    throw new Exception("Erro ao obter os dados do clima. ERRO: " + response.StatusCode);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Falha na requisição da API.", ex);
            }
            return weatherResponse;
        }
    }
}
