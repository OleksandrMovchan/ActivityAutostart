using System;
using ActivityAutostart.Routers;
using ActivityAutostart.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Portable.Controllers.Detail;

namespace ActivityAutostart.Activities
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity
    {
        private string _id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
        }

        protected override void OnResume()
        {
            base.OnResume();
            InitData();
            InitController();
        }

        private void InitData()
        {
            var extras = Intent.Extras;
            if (extras != null)
            {
                _id = extras.GetString(Constants.Id, "");
            }
        }
        
        private void InitController()
        {
            var view = FindViewById<DetailView>(Resource.Id.viewDetail);
            var router = new DetailRouter(new WeakReference<Context>(this));

            var controller = new DetailController(view, router);
            controller.SetData(_id);
        }
    }
}