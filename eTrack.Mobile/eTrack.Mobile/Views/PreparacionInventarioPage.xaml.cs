using eTrack.Mobile.Models;
using eTrack.Mobile.ViewModels;
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
        public ObservableCollection<AssetModel> MyList { get; set; }
        public PreparacionInventarioPage()
        {
            InitializeComponent();

            BindingContext = new PreparacionInventarioViewModel(Navigation);
            MyList = new ObservableCollection<AssetModel>();

            for (int i = 1; i < 5; i++)
            {
                MyList.Add(new AssetModel() { Id = i.ToString(), Code = "Código" + i.ToString(), SapId = "SapId" + i.ToString(), Location = "Ubicación" + i.ToString() });
            }

            ContactsList.ItemsSource = MyList;
        }
    }
}