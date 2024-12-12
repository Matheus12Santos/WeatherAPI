using System.Diagnostics;
using WeatherAPI.ViewModels;

namespace WeatherAPI.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}