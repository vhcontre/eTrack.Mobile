
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTrack.Mobile.ViewModels.Asset;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarPage : ContentPage
    {
        private AssetFindViewModel viewModel;
        public BuscarPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AssetFindViewModel(Navigation);
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            switch (picker.SelectedIndex)
            {
                case 0:
                    argData.Placeholder = "Ingrese Tag";
                    argData.IsVisible = true;
                    argDate.IsVisible = false;
                    break;
                case 1:
                    argData.Placeholder = "Ingrese código";
                    argData.IsVisible = true;
                    argDate.IsVisible = false;
                    break;
                case 2:
                    argDate.IsVisible = true;
                    argData.IsVisible = false;
                    argDate.Date = DateTime.Now;
                    break;
                default:
                    break;
            }
        }
    }
}