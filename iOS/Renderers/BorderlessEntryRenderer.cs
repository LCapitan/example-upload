using System;
using MeemicMobileApp.CustomControls.Base;
using MeemicMobileApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace MeemicMobileApp.iOS.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}
