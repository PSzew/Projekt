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
		List <string> Waluty = new List<string>();
		public Kantor ()
		{
			InitializeComponent ();
			Waluty.Add("PLN");
			Waluty.Add("EUR");
			Waluty.Add("GBP");
			Waluty.Add("USD");
			Waluty.Add("CZK");
            Picker.ItemsSource = Waluty;
            Picker2.ItemsSource = Waluty;
        }

        private async void Exchange(object sender, EventArgs e)
        {
			if(Picker.SelectedIndex >=0 && Picker2.SelectedIndex >= 0 && Value.Text != null && Value.Text !=string.Empty) 
			{
                Currency.TextColor = Xamarin.Forms.Color.Blue;
				Currency.Text = "Zamiana walut, proszę czekać";
				Currency.FontSize = 25;
                string valut1 = Waluty[Picker.SelectedIndex];
				string valut2 = Waluty[Picker2.SelectedIndex];
				string value = Value.Text;
				string request = "https://api.apilayer.com/exchangerates_data/convert?to="+valut2+"&from="+valut1+"&amount="+value+"&apikey=HraVKaXnOFrP15XQkrOpGgSLiJxqKdM7";
				try
				{
                    HttpClient client = new HttpClient();
                    var json = await client.GetStringAsync(request);
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);

                    Currency.TextColor = Xamarin.Forms.Color.Black;
                    Currency.FontSize = 40;
                    Currency.Text = Math.Round(myDeserializedClass.result, 2).ToString() + " " + valut2;
                }
				catch (Exception)
				{
                          
                    Currency.FontSize = 40;
                    Currency.TextColor = Xamarin.Forms.Color.Red;
                    Currency.Text = "Błąd połączenia!";
                }
                		
            }
			else if(Picker.SelectedIndex < 0 || Picker2.SelectedIndex < 0)
			{
                Currency.FontSize = 40;
                Currency.TextColor = Xamarin.Forms.Color.Red;
				Currency.Text = "Nie podano walut!";
            }
			else if(Value.Text == null || Value.Text == string.Empty)
			{
                Currency.FontSize = 40;
                Currency.TextColor = Xamarin.Forms.Color.Red;
                Currency.Text = "Nie podano ilosci!";
            }

        }
    }
}