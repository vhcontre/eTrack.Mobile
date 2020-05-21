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

        public PreparacionInventarioPage()
        {
            InitializeComponent();

            BindingContext = new PreparacionInventarioViewModel(Navigation);

        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}