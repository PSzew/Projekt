using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KalkulatorSystem : ContentPage
    {
        public KalkulatorSystem()
        {
            InitializeComponent();
        }

        static bool binaryg = true; //Zmienne przechowywujące to czy tekst wpisany do pola jest prawidłowy
        static bool hexg = true;
        private void Dec(object sender, TextChangedEventArgs e) //funkcja przeliczająca z systemu 10 na 2 i 16
        {
            if (DEC.Text.Length != 0) //Warunek jeśli długość tektu w polu jest inny niż 0 funkcja się wykonuje
            {
                BIN.Text = Convert.ToString(Convert.ToInt32(DEC.Text, 10), 2); //konwersja liczby na liczbę w systemie dwójkowym.
                HEX.Text = Convert.ToInt32(DEC.Text, 10).ToString("X");
            }          
        }

        private void Hex(object sender, TextChangedEventArgs e)
        {
            if (HEX.Text.Length == 0)
                hexg = false;
            else hexg = true;
            SolidColorBrush brush2 = new SolidColorBrush(Xamarin.Forms.Color.Gray);
            HEX.Background = brush2;
            if (System.Text.RegularExpressions.Regex.IsMatch(HEX.Text, @"\A\b[0-9a-fA-F]+\b\Z") == false) //sprawdzenie czy liczba w systemie 16 pasuje do tablicy znaków przy pomocy regexów
            {
                SolidColorBrush brush = new SolidColorBrush(Xamarin.Forms.Color.Red);
                HEX.Background = brush; //zmiana koloru tła jeśli podana wartość nie pasuje do tablicy znaków regex
                hexg = false; //ustawienie statusu na false
            }
            if(hexg)
            {
                BIN.Text = Convert.ToString(Convert.ToInt32(HEX.Text, 16), 2); //konwersja pomiędzy systemami liczbowymi
                DEC.Text = Convert.ToInt32(HEX.Text, 16).ToString(""); //konwersja pomiędzy systemami liczbowymi
            }
            if(HEX.Text == "")
            {
                HEX.Background = brush2;
            }
        }

        private void Binary(object sender, TextChangedEventArgs e)
        {
            SolidColorBrush brush2 = new SolidColorBrush(Xamarin.Forms.Color.Gray);
            BIN.Background = brush2;
            if(BIN.Text.Length == 0)
                binaryg= false;
            else binaryg= true;
            for (int i=0;i<BIN.Text.Length;i++) //sprawdzenie czy liczba zawiera prawidłowe znaki
            {
                if (BIN.Text[i].ToString() != "1")
                {
                    if(BIN.Text[i].ToString() != "0")
                    {
                        SolidColorBrush brush = new SolidColorBrush(Xamarin.Forms.Color.Red);
                        BIN.Background = brush; //zmiana koloru tła
                        binaryg = false; //ustawienie statusu na false
                    }
                }               
            }
            if (binaryg)
            {
                DEC.Text = Convert.ToInt32(BIN.Text, 2).ToString(); //konwersja pomiędzy systemami liczbowymi
                HEX.Text = Convert.ToInt32(BIN.Text, 2).ToString("X"); //konwersja pomiędzy systemami liczbowymi

            }
        }
    }
}
