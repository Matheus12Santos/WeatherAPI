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
        private readonly HttpClient _httpClient;
        private string apiKey = "33b02ef843560aff01c77e421396b9bb";
        private WeatherResponse? weatherResponse;
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

        public async Task<WeatherResponse?> GetWeatherByCity(string cityName)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse, jsonSerializerOptions) ?? new WeatherResponse();

                    // Verifique se 'main' foi preenchido corretamente
                    if (weatherResponse.main == null)
                    {
                        Console.WriteLine("Erro: 'main' não foi encontrado na resposta.");
                    }
                    else
                    {
                        Console.WriteLine($"Temperatura: {weatherResponse.main.Temp}");
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
            System.Diagnostics.Debug.WriteLine($"Resposta da API: {weatherResponse}");
            return weatherResponse;
        }
    }
}
