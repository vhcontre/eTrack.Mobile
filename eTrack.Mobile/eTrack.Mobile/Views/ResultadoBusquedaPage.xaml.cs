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
    public partial class ResultadoBusquedaPage : ContentPage
    {
        readonly ResultadoBusquedaViewModel viewModel;
        public ResultadoBusquedaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ResultadoBusquedaViewModel(Navigation);
            lblCount.Text = string.Format("{0} filas.", viewModel.Items.Count);
        }
    }
}