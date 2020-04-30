using eTrack.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreparacionInventarioPage : ContentPage
    {
        private ObservableCollection<Asset> myList;

        public ObservableCollection<Asset> MyList
        {
            get { return myList; }
            set { myList = value; }
        }
        public PreparacionInventarioPage()
        {
            InitializeComponent();
            MyList = new ObservableCollection<Asset>();

            for (int i = 1; i < 6; i++)
            {
                MyList.Add(new Asset() { Id = i, Code = "Código" + i.ToString(), SapId = "SapId" + i.ToString(), Location = "Location" + i.ToString() });
            }

            ContactsList.ItemsSource = MyList;
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {

        }

        async private void Siguiente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventarioPage());
        }
    }
}