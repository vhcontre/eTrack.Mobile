using eTrack.Mobile.Models;
using eTrack.Mobile.Services;
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
    public partial class ResultadoHistorialPage : ContentPage
    {
        readonly ResultadoHistorialViewModel viewModel;
        public ResultadoHistorialPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ResultadoHistorialViewModel(Navigation);
            lblCount.Text = string.Format("{0} filas.", viewModel.Items.Count);
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string current = (e.CurrentSelection.FirstOrDefault() as AssetAuditModel)?.AssetId;
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[Sin selección]" : current;
            btnEdit.CommandParameter = current;
            btnDelete.CommandParameter = current;
        }
    }
}