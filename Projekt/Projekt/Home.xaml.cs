using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        static double liczba1 = 0;
        static double liczba2 = 0;
        static string liczbatmp = "";
        static string znak = "";
        static string wynik = "";
        static bool resultset = false;

        public Home()
        {
            InitializeComponent();
        }

        private void sevenClicked(object sender, EventArgs e)
        {
            if(liczbatmp.Length>6)
            {
                return;
            }
            liczbatmp += "7";
            result.Text=liczbatmp;
            refresh();
        }

        private void eightClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "8";
            refresh();
        }

        private void NineClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "9";
            refresh();
        }

        private void MultClicked(object sender, EventArgs e)
        {
            if (znak == "")
            {
                if (resultset == false)
                {
                    double.TryParse(liczbatmp, out liczba1);
                    znak = "*";
                    liczbatmp = "";
                }
                else
                {
                    znak = "*";
                }
                refresh();
            }
            refresh();
        }

        private void FourClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "4";
            refresh();
        }

        private void FiveClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "5";
            refresh();
        }

        private void SixClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "6";
            refresh();
        }

        private void AddClicked(object sender, EventArgs e)
        {
            if(znak == "")
            {
                if(resultset == false)
                {
                    double.TryParse(liczbatmp, out liczba1);
                    znak = "+";
                    liczbatmp = "";
                }
                else
                {
                    znak = "+";
                }
                refresh();
            }
            refresh();
        }

        private void OneClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "1";
            refresh();
        }

        private void TwoClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "2";
            refresh();
        }

        private void ThreeClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "3";
            refresh();
        }

        private void SubClicked(object sender, EventArgs e)
        {
            if (znak == "")
            {
                if (resultset == false)
                {
                    double.TryParse(liczbatmp, out liczba1);
                    znak = "-";
                    liczbatmp = "";
                }
                else
                {
                    znak = "-";
                }
                refresh();
            }
            refresh();
        }


        private void DivClicked(object sender, EventArgs e)
        {
            if (znak == "")
            {
                if (resultset == false)
                {
                    double.TryParse(liczbatmp, out liczba1);
                    znak = "/";
                    liczbatmp = "";
                }
                else
                {
                    znak = "/";
                }
                refresh();
            }
            refresh();
        }

        private void ZeroClicked(object sender, EventArgs e)
        {
            if (liczbatmp.Length > 6)
            {
                return;
            }
            liczbatmp += "0";
            refresh();
        }

        private void ComClicked(object sender, EventArgs e)
        {
            if(liczbatmp.Length < 6)
            {
                if (liczbatmp == "")
                {
                    liczbatmp = "0,";
                    refresh();
                }
                else
                {
                    liczbatmp += ",";
                    refresh();
                }
            }
            return;
        }
        private void Clear(object sender, EventArgs e)
        {
            liczba1 = 0;
            liczba2 = 0;
            liczbatmp = "";
            znak = "";
            wynik = "";
            result.Text = "0";
            resultset = false;
        }
        private void refresh()
        {
            if(wynik == "" && liczbatmp == "")
            {
                result.Text = "0";
            }
            else if(liczbatmp != "")
            {
                result.Text=liczbatmp;
            }
            else
            {
                result.Text = wynik;
            }
        }

        private void EquClicked(object sender, EventArgs e)
        {
           if(znak != "")
            {
                double.TryParse(liczbatmp, out liczba2);
                liczbatmp = "";
                if(znak == "+")
                {
                    wynik = Math.Round((liczba1 + liczba2), 3).ToString();
                    liczba1 = double.Parse(wynik);
                    resultset = true;
                    liczba2 = 0;
                    znak = "";
                }
                if (znak == "-")
                {
                    wynik = Math.Round((liczba1 - liczba2), 3).ToString();
                    liczba1 = double.Parse(wynik);
                    resultset = true;
                    liczba2 = 0;
                    znak = "";
                }
                if (znak == "*")
                {
                    wynik = Math.Round((liczba1 * liczba2), 3).ToString();
                    liczba1 = double.Parse(wynik);
                    resultset = true;
                    liczba2 = 0;
                    znak = "";
                }
                if (znak == "/")
                {
                    wynik = Math.Round((liczba1 / liczba2),3).ToString();
                    liczba1 = double.Parse(wynik);
                    resultset = true;
                    liczba2 = 0;
                    znak = "";
                }
                refresh();
            }
        }
    }
}