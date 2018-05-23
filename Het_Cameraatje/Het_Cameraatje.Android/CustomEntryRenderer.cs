 using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Het_Cameraatje;
using Het_Cameraatje.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Het_Cameraatje.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                /* Set BAckground of Entry */
                var gradientDawable = new GradientDrawable();
                gradientDawable.SetCornerRadius(100f);
                gradientDawable.SetColor(Android.Graphics.Color.Argb(60, 255, 255, 255));
                gradientDawable.SetStroke(2, Android.Graphics.Color.Black); 
                Control.SetBackground(gradientDawable);
                /* Align Entry Text Center */
                Control.Gravity = GravityFlags.CenterHorizontal;
            }
        }
    }
}