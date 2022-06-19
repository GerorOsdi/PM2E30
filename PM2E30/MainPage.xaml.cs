using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using Plugin.Media;
using PM2E30.Models;
using PM2E30.View;

namespace PM2E30
{
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile PhotoFile = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (PhotoFile == null)
            {
                await DisplayAlert("Aviso", "No se ha tomado la fotografía", "Aceptar");

                return;
            }

            var datPlace = new Lugares
            {
                latitud = txtLatitude.Text,
                longitud = txtLongitud.Text,
                desc = txtDesc.Text,
                photo = ConvertImageToByteArray()
            };


            var resul = await App.dbPlace.savePlace(datPlace);

            if (resul > 0)
            {
                await DisplayAlert("Notificacion", "Dato Guardado con Exito", "Aceptar");
                limpiar();
            }
            else
            {
                await DisplayAlert("Erro", "Dato no se pudo almacenar", "Aceptar");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listLugares());
        }

        private async void btnPhoto_Clicked(object sender, EventArgs e)
        {
            PhotoFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "Prueba1.jpg",
                SaveToAlbum = true,
            });

            if (PhotoFile != null)
            {
                viewPlace.Source = ImageSource.FromStream(() => { return PhotoFile.GetStream(); });
                getLocation();
            }
        }

        protected async void getLocation()
        {
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                txtLatitude.Text = location.Latitude.ToString();
                txtLongitud.Text = location.Longitude.ToString();
            }
        }

        private Byte[] ConvertImageToByteArray()
        {
            if (PhotoFile != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = PhotoFile.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }

        private void limpiar()
        {
            txtLatitude.Text = "";
            txtLongitud.Text = "";
            txtDesc.Text = "";
            viewPlace.Source = null;
        }
    }
}
