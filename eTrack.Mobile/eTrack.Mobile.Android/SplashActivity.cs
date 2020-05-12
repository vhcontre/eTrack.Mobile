using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace eTrack.Mobile.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task.Factory.StartNew(SplashStartup);
         }

        public override void OnBackPressed() { }

        async void SplashStartup()
        {
            await Task.Delay(1000); 
            StartActivity(new Intent(Application.Context, typeof (MainActivity)));
        }
    }
}