using System;
using ActivityAutostart.Routers;
using ActivityAutostart.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Portable.Controllers.Main;
using Portable.Controllers.Main.Interfaces;

namespace ActivityAutostart
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private IMainController _controller;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitMainController();
            _controller.Subscribe();
        }

        protected override void OnPause()
        {
            base.OnPause();

            //_controller.Unsubscribe();
        }

        private void InitMainController()
        {
            var view = FindViewById<MainView>(Resource.Id.mainView);
            var router = new MainRouter(new WeakReference<Context>(this));
            _controller = new MainController(view, router);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == Constants.RequestCodeSelector)
            {
                _controller.RunTimer();
            }
            else if (requestCode == Constants.RequestCodeDetail)
            {
                _controller.ShowNext();
            }
        }
    }
}

