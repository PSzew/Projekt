using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projekt
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlyOut.ListView.ItemSelected += OnselectedItem;
        }

        private void OnselectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyItemOut;
            if (item != null) 
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                FlyOut.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
