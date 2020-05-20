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
    public partial class ActionPage : ContentPage
    {
        private AssetActionViewModel viewModel;
        public ActionPage()
        {
            this.Init(false);
        }
        public ActionPage(bool isVisible = false)
        {
            // Si la variable isVisible es true, se muestra el boton 'Ver Activos' y se oculta el boton 'Ejecutar'
            this.Init(isVisible);

        }

        private void Init(bool isVisible)
        {
            InitializeComponent();
            BindingContext = viewModel = new AssetActionViewModel(Navigation, isVisible);
            lblCount.Text = string.Format("{0} filas.", viewModel.Items.Count);
            btnActivos.IsVisible = isVisible;
            btnEjecutar.IsVisible = !isVisible;
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (e.CurrentSelection.FirstOrDefault() as AssetActionModel);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current.Id) ? "[Sin selección]" : string.Format("{0}", current.Name);
            btnActivos.CommandParameter = string.Format("Id: {0} Nombre: {1}", current.Id, current.Name);
        }
    }
}