using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Xna.Framework;
using Android.Views;
using System.IO;

namespace AndroidTest
{
    [Activity(Label = "AndroidTest"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //// Read the contents of our asset
            //string content;
            //using (StreamReader sr = new StreamReader(Assets.Open("read_asset.txt")))
            //{
            //    content = sr.ReadToEnd();
            //}

            Game1.Activity = this;
            var g = new Game1();
            SetContentView(g.Window);
            g.Run();
        }


    }
}
