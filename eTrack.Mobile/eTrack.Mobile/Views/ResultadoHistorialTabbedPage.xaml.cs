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
    public partial class ResultadoHistorialTabbedPage : TabbedPage
    {
        readonly ResultadoHistorialViewModel viewModel;
        public ResultadoHistorialTabbedPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ResultadoHistorialViewModel(Navigation);
        }

        private void TappedOnClick(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (AssetAuditModel)layout.BindingContext;
            Application.Current.MainPage.DisplayAlert("AssetAuditModel", item.Id, "Ok");

        }
    }
}