using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace ActivityAutostart.Activities
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
        }
    }
}