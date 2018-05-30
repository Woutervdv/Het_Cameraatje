using Android.Content;
using Android.Graphics.Drawables; 
using Android.Views; 
using CleanProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace CleanProject.Droid
{
    class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                /* Set BAckground of Entry */
                var gradientDawable = new GradientDrawable();
                gradientDawable.SetCornerRadius(20f);
                gradientDawable.SetColor(Android.Graphics.Color.Rgb(85, 85, 85));
                Control.SetBackground(gradientDawable);
                /* Align Entry Text Center */
                Control.Gravity = GravityFlags.CenterHorizontal;
            }
        }
    }
}