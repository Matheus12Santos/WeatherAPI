using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAPI.Models;
using WeatherAPI.Services;

namespace WeatherAPI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public readonly MainService mainService;
        public WeatherResponse? weatherResponse;

        [ObservableProperty]
        private float _temp;

        //[ObservableProperty]
        //public int pressure;
        //[ObservableProperty]
        //public int humidity;
        //[ObservableProperty]
        //public int weatherId;
        //[ObservableProperty]
        //public string clime;
        //[ObservableProperty]
        //public string climeDescription;
        //[ObservableProperty]
        //public string climeIcon;
        //[ObservableProperty]
        //public float speed;
        //[ObservableProperty]
        //public int deg;
        //[ObservableProperty]
        //public float gust;

        private string? _cityName;

        public string? CityName
        {
            get => _cityName;
            set => SetProperty(ref _cityName, value);
        }

        public ICommand SearchButtonPressedCommand { get; }

        public MainViewModel()
        {
            mainService = new MainService();            
            SearchButtonPressedCommand = new Command(async ()=>
            {
                if (!string.IsNullOrWhiteSpace(CityName))
                {
                    await GetCity();
                }
                else
                {
                    //MUDAR ESSA PARTE DEPOIS
                    Console.WriteLine("ERRO: Faz direito");
                }
            });
        }

        // Método para obter informações da cidade
        public async Task GetCity()
        {
            // Obtenha o resultado da API
            weatherResponse = await mainService.GetWeatherByCity(_cityName ?? string.Empty);

            // Verifique se o resultado não é nulo e se a propriedade main existe
            if (weatherResponse?.main != null)
            {
                // Atualize a propriedade Temp com o valor correto
                Temp = weatherResponse.main.Temp;
                //pressure = weatherResponse.main.Pressure;
                //humidity = weatherResponse.main.Humidity;
                //weatherId = weatherResponse.weather.WeatherId;
                //clime = weatherResponse.weather.Clime;
                //climeDescription = weatherResponse.weather.ClimeDescription;    
                //climeIcon = weatherResponse.weather.ClimeIcon;
                //speed = weatherResponse.wind.Speed;
                //deg = weatherResponse.wind.Deg;
                //gust = weatherResponse.wind.Gust;
            }
            else
            {
                // Se não encontrar os dados, exiba uma mensagem ou faça algo apropriado
                Temp = 0; // ou trate de forma adequada
                Console.WriteLine(Temp);
            }
        }        
    }
}
