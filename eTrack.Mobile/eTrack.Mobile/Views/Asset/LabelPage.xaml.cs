using eTrack.Mobile.Models;
using eTrack.Mobile.ViewModels.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views.Asset
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelPage : ContentPage
    {
        readonly AssetLabelViewModel viewModel;
        public LabelPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AssetLabelViewModel(Navigation);
            lblCount.Text = string.Format("{0} filas.", viewModel.Items.Count);
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (e.CurrentSelection.FirstOrDefault() as AssetLabelModel);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current.Id) ? "[Sin selección]" : string.Format("{0}", current.Key);
        }
    }
}