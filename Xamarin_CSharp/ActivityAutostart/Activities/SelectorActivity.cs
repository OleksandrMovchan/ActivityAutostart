using System.Collections.Generic;
using System.Linq;
using ActivityAutostart.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Portable.Controllers.Selector;
using Portable.Controllers.Selector.Interfaces;
using Portable.Repositories;

namespace ActivityAutostart.Activities
{
    [Activity(Label = "SelectorActivity")]
    public class SelectorActivity : AppCompatActivity
    {

        private const string PreferencesName = "SETTINGS_DEFAULT";
        private const string DataKey = "data";
        private const string IntervalKey = "interval";
        private const string ShowingKey = "showing";
        private const string SkipKey = "skip";

        private bool _wasShowed = false;

        private ISelectorController _controller;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_selector);
        }

        protected override void OnResume()
        {
            base.OnResume();

            GetFromShared();
            InitController();
            _controller.Subscribe();
            _controller.OnReturn += SetIntoShared;

            if (_wasShowed)
            {
                var button = FindViewById<Button>(Resource.Id.selectorBtnConfirm);
                button.PerformClick();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            _controller.Unsubscribe();
            _controller.OnReturn -= SetIntoShared;
        }

        private void GetFromShared()
        {
            var preferences = GetSharedPreferences(PreferencesName, FileCreationMode.Private);
            var dataIds = preferences.GetStringSet(DataKey, new List<string>());
            var interval = preferences.GetInt(IntervalKey, 240);
            var showingTime = preferences.GetInt(ShowingKey, 30);
            _wasShowed = preferences.GetBoolean(SkipKey, false);

            DataRepository.GetInstance().SetCheckedData(dataIds.ToList());

            var selectorInterval = FindViewById<EditText>(Resource.Id.selectorInterval);
            var selectorTime = FindViewById<EditText>(Resource.Id.selectorTime);

            selectorInterval.Text = interval.ToString();
            selectorTime.Text = showingTime.ToString();
        }

        private void InitController()
        {
            var view = FindViewById<SelectorView>(Resource.Id.selectorView);

            _controller = new SelectorController(view);
            _controller.Init();
        }

        private void SetIntoShared()
        {
            var editor = GetSharedPreferences(PreferencesName, FileCreationMode.Private).Edit();
            var list = new List<string>();
            foreach (var data in DataRepository.GetInstance().CheckedData)
            {
                list.Add(data.Id);
            }

            var selectorInterval = FindViewById<EditText>(Resource.Id.selectorInterval);
            var selectorTime = FindViewById<EditText>(Resource.Id.selectorTime);
            
            int.TryParse(selectorInterval.Text, out int interval);
            int.TryParse(selectorTime.Text, out int showingTime);

            TimingRepository.GetInstance().Interval = interval;
            TimingRepository.GetInstance().ShowingTime = showingTime;

            editor.PutStringSet(DataKey, list);
            editor.PutInt(IntervalKey, interval);
            editor.PutInt(ShowingKey, showingTime);
            editor.PutBoolean(SkipKey, true);
            editor.Apply();

            RunOnUiThread(OnBackPressed);
        }
    }
}