using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Projekt.ClassModel;

namespace Projekt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Kantor : ContentPage
	{
		List <string> Waluty = new List<string>(); //Zadeklarowanie listy walut
		public Kantor ()
		{
			InitializeComponent ();
			Waluty.Add("PLN"); //przypisanie liście wartości
			Waluty.Add("EUR");
			Waluty.Add("GBP");
			Waluty.Add("USD");
			Waluty.Add("CZK");
            Picker.ItemsSource = Waluty; //ustawienie data bindingu pickerów na liste walut
            Picker2.ItemsSource = Waluty;
        }

        private async void Exchange(object sender, EventArgs e) //Asynchroniczna funkcja do przeliczenia walut
        {
			if(Picker.SelectedIndex >=0 && Picker2.SelectedIndex >= 0 && Value.Text != null && Value.Text !=string.Empty) //sprawdzenie czy waluty zostały wybrane oraz czy ilość została wpisana
			{
                Currency.TextColor = Xamarin.Forms.Color.Blue; //zmiana koloru label'a na niebieski
				Currency.Text = "Zamiana walut, proszę czekać"; //wypisanie statusu
				Currency.FontSize = 25;
                string valut1 = Waluty[Picker.SelectedIndex]; //ustawienie pierwszej waluty
				string valut2 = Waluty[Picker2.SelectedIndex]; //ustawienie drugiej waluty
				string value = Value.Text; //ustawienie ilosci
				string request = "https://api.apilayer.com/exchangerates_data/convert?to="+valut2+"&from="+valut1+"&amount="+value+"&apikey=HraVKaXnOFrP15XQkrOpGgSLiJxqKdM7"; //Tworzenie zapytania do API
				try //Blok try catch do obsłużenia wyjątku w wypadku np. Braku dostępu do internetu lub przerwie w działaniu API
				{
                    HttpClient client = new HttpClient(); //Utworzenie obiektu HttpClient
                    var json = await client.GetStringAsync(request); //Pobranie JSON'a z API do zmiennej
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json); //Deserializacja JSON'a do obiektu

                    Currency.TextColor = Xamarin.Forms.Color.Black; 
                    Currency.FontSize = 40;
                    Currency.Text = Math.Round(myDeserializedClass.result, 2).ToString() + " " + valut2; //Wypisanie wyniku
                }
				catch (Exception) //obsługa wyjątków
				{
                          
                    Currency.FontSize = 40;
                    Currency.TextColor = Xamarin.Forms.Color.Red;
                    Currency.Text = "Błąd połączenia!"; //ustawienie statusu jako błąd połączenia
                }
                		
            }
			else if(Picker.SelectedIndex < 0 || Picker2.SelectedIndex < 0)
			{
                Currency.FontSize = 40;
                Currency.TextColor = Xamarin.Forms.Color.Red;
				Currency.Text = "Nie podano walut!"; //Ustawienie statusu na bład nie podanych walut
            }
			else if(Value.Text == null || Value.Text == string.Empty)
			{
                Currency.FontSize = 40;
                Currency.TextColor = Xamarin.Forms.Color.Red;
                Currency.Text = "Nie podano ilosci!"; //Ustawienie statusu na bład nie podanej ilości
            }

        }
    }
}
