using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2E30.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E30.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listLugares : ContentPage
    {
        public listLugares()
        {
            InitializeComponent();
        }

        private async void lstPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                Lugares itemSelc = e.CurrentSelection[0] as Lugares;

                bool rest = await DisplayAlert("Aviso","¿Desea ir a la ubicación seleccionada?","Aceptar","Cancelar");

                if(rest == true)
                {
                    await Navigation.PushAsync(new Maps(itemSelc.latitud, itemSelc.longitud, itemSelc.desc, itemSelc.photo));
                }
                else
                {
                    rest = false;
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lstPlaces.ItemsSource = await App.dbPlace.getPlaces();
        }


        /*private async void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            await DisplayAlert("Aviso", "probando scroll", "ok");
        }*/
    }
}