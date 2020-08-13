using SimpleSample;
using SimpleSample.UWP;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.UWP.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(SfButtonExt), typeof(CustomButtonRenderer))]
namespace SimpleSample.UWP
{
    class CustomButtonRenderer : SfButtonRenderer
    {
        SfButtonExt sfButton;
        protected override void OnElementChanged(ElementChangedEventArgs<SfBorder> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.PointerMoved += Control_PointerMoved;
                Control.PointerExited += Control_PointerExited;
            }

            if(e.NewElement != null)
            {
                sfButton = e.NewElement as SfButtonExt;
            }
        }

        private void Control_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Windows.UI.Core.CoreCursor arrowCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
            Window.Current.CoreWindow.PointerCursor = arrowCursor;
        }

        private void Control_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Windows.UI.Core.CoreCursor handCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            Window.Current.CoreWindow.PointerCursor = handCursor;
            StartAnimation();
        }

        async void StartAnimation()
        {
            //change the scale value based on your requirement
            bool isCancelled = await sfButton.ScaleTo(1.1, 500);
            if (!isCancelled)
            {
                await sfButton.ScaleTo(1, 500);
            }
        }
    }
}
