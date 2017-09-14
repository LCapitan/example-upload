using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MeemicMobileApp.ViewModels.MyMeemic.IDCards;
using MeemicMobileApp.Views.MyMeemic.IDCards;
using UIKit;
using Xamarin.Forms;

namespace MeemicMobileApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // @NOTE(sjv): Below is how we will force rotation
            // Xamarin.Forms has a lot of limitations 
            MessagingCenter.Subscribe<IDCardView>(this, "forceLandscape", (obj) =>  
            {
                UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int) (UIInterfaceOrientation.LandscapeLeft)), new NSString("orientation"));    
            });

            MessagingCenter.Subscribe<IDCardViewModel>(this, "forcePortait", (obj) => 
            {
                UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
			});

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
