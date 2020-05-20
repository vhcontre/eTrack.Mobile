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
    public partial class ReportesPage : ContentPage
    {
        private ReportesViewModel viewModel;

        public ReportesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ReportesViewModel(Navigation);
        }

        private void Handle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOption = (sender as Picker).SelectedItem;
            viewModel.ChangeOptionCommand.Execute(selectedOption);
        }
    }
}