using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using PM2E30.Conver;

namespace PM2E30.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maps : ContentPage
    {
        string descr;
        double latitud, longitud;
        byte [] bytePhoto = null;
        //var PlacePhoto = null;

        public Maps()
        {
            InitializeComponent();
        }

        public Maps(string lati, string longi, string desc, byte[] pFoto)
        {
            InitializeComponent();
            latitud = double.Parse(lati);
            longitud = double.Parse(longi);
            descr = desc;
            bytePhoto = pFoto;
            //placePhoto.Source();
        }

        private async void btnShare_Clicked(object sender, EventArgs e)
        {
            var PlacePhoto = await MediaPicker.PickPhotoAsync();
           
            await Share.RequestAsync(new ShareFileRequest()
            {
                Title = descr,
                File = new ShareFile(PlacePhoto)
                
            });
        }

        protected async override void OnAppearing()
        {
            var pinMap = new Pin() {
                Position = new Position(latitud, longitud),
                Label = descr
            };

            mapa.Pins.Add(pinMap);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitud,longitud),Distance.FromMeters(100.00)));
        }

    }
}