using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Xna.Framework;
using Android.Views;
using System.IO;
using Android.Content.Res;

namespace Blocker
{
    [Activity(Label = "Blocker"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]

    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        
      
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

          
            Game1.Activity = this;
            var g = new Game1();
            SetContentView(g.Window);
            g.Run();
        }

        protected override void OnResume()
        {
            //Game1.Activity.OnConfigurationChanged(orientation);
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

    }
}

