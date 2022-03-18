using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GesturesPractice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imagen = (Image)sender;
            await this.Navigation.PushModalAsync(new Modal1(imagen));

        }

        async void OnSwipeGestureRecognizerSwiped(object sender, EventArgs args)
        {
            var imagen2 = (Image)sender;
            await this.Navigation.PushModalAsync(new Modal2(imagen2));
        }

        async void OnTapExit(object sender, EventArgs args)
        {
            var imagen3 = (Image)sender;
            await this.Navigation.PushModalAsync(new Modal1(imagen3));

        }
    }

}
