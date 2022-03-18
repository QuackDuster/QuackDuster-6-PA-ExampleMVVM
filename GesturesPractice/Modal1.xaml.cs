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

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
             
            this.Navigation.PopModalAsync();
        }

        private double startScale;
        private double currentScale;
        private double xOffset;
        private double yOffset;

        void OnPinchZoom(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }

            if (e.Status == GestureStatus.Running)
            {
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);
                Content.TranslationX = Math.Min(0, Math.Max(targetX, -Content.Width * (currentScale - 1)));
                Content.TranslationY = Math.Min(0, Math.Max(targetY, -Content.Height * (currentScale - 1)));
            }

            Content.Scale = currentScale;
            {
                if (e.Status == GestureStatus.Completed)
                {
                    xOffset = Content.TranslationX;
                    yOffset = Content.TranslationY;
                }
            }

        }
    }
}