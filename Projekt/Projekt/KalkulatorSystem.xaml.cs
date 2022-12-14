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

        static bool binaryg = true;
        static bool hexg = true;
        private void Dec(object sender, TextChangedEventArgs e)
        {
            if (DEC.Text.Length != 0)
            {
                BIN.Text = Convert.ToString(Convert.ToInt32(DEC.Text, 10), 2);
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
            if (System.Text.RegularExpressions.Regex.IsMatch(HEX.Text, @"\A\b[0-9a-fA-F]+\b\Z") == false)
            {
                SolidColorBrush brush = new SolidColorBrush(Xamarin.Forms.Color.Red);
                HEX.Background = brush;
                hexg = false;
            }
            if(hexg)
            {
                BIN.Text = Convert.ToString(Convert.ToInt32(HEX.Text, 16), 2);
                DEC.Text = Convert.ToInt32(HEX.Text, 16).ToString("");
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
            for (int i=0;i<BIN.Text.Length;i++)
            {
                if (BIN.Text[i].ToString() != "1")
                {
                    if(BIN.Text[i].ToString() != "0")
                    {
                        SolidColorBrush brush = new SolidColorBrush(Xamarin.Forms.Color.Red);
                        BIN.Background = brush;
                        binaryg = false;
                    }
                }               
            }
            if (binaryg)
            {
                DEC.Text = Convert.ToInt32(BIN.Text, 2).ToString();
                HEX.Text = Convert.ToInt32(BIN.Text, 2).ToString("X");

            }
        }
    }
}