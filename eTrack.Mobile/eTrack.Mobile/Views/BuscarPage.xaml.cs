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
    public partial class BuscarPage : ContentPage
    {
        public BuscarPage()
        {
            InitializeComponent();
            BindingContext = new AssetFindViewModel(navigation: Navigation);
        }

        
    }

    //void Find_OnPickerSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var picker = (Picker)sender;
    //    int selectedIndex = picker.SelectedIndex;
    //    if (selectedIndex != -1)
    //    {
    //        var text = (string)picker.ItemsSource[selectedIndex];
    //        DisplayAlert("ItemsSource", text, "Ok");
    //    }
    //}


}