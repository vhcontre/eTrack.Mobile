using eTrack.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventarioPage : ContentPage
    {
        public InventarioPage()
        {
            InitializeComponent();
            BindingContext = new InventarioViewModel(Navigation);
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}