using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GesturesPractice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modal1 : ContentPage
    {
        public Modal1(object sender)
        {
            InitializeComponent();
            var imgModal = (Image)sender;
            img.Source = imgModal.Source;

        }
        void PinchUpdater(object sender, PinchGestureUpdatedEventArgs e)
        {

            this.Navigation.PopModalAsync();
        }
    }
}