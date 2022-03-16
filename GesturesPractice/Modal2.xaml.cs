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
    public partial class Modal2 : ContentPage
    {
        public Modal2(Image imageSender)
        {
            InitializeComponent();
            img2.Source = imageSender.Source;
        }

        void OnSwipeGestureRecognizerSwiped(object sender, EventArgs args)
        {
              
            this.Navigation.PopModalAsync();
        }
    }
}