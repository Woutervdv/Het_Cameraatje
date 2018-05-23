using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Het_Cameraatje.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace Het_Cameraatje.Droid
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                /* Set BAckground of Entry */
                var gradientDawable = new GradientDrawable();
                gradientDawable.SetCornerRadius(300f);
                gradientDawable.SetColor(Android.Graphics.Color.Argb(60, 255, 255, 255));
                gradientDawable.SetStroke(2, Android.Graphics.Color.Black);
                Control.SetBackground(gradientDawable);
                /* Align Entry Text Center */
                Control.Gravity = GravityFlags.CenterHorizontal;
            }
        }
    }
}