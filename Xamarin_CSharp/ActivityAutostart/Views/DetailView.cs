using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Widget;
using Portable.Controllers.Detail.Interfaces;

namespace ActivityAutostart.Views
{
    [Register("ActivityAutostart.Views.DetailView")]
    public class DetailView : ConstraintLayout, IDetailView
    {
        public DetailView(Context context) : base(context)
        {
            Init();
        }

        public DetailView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public DetailView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            var inflater = ((Activity)Context).LayoutInflater;
            inflater.Inflate(Resource.Layout.view_detail, this, true);
        }

        public void SetColor(int red, int green, int blue)
        {
            var detailLayout = FindViewById<ConstraintLayout>(Resource.Id.detailLayout);
            (Context as Activity)?.RunOnUiThread(() =>
            {
                detailLayout.SetBackgroundColor(Color.Rgb(red, green, blue));
            });
        }

        public void SetTitle(string title)
        {
            var titleView = FindViewById<TextView>(Resource.Id.detailContent);
            (Context as Activity)?.RunOnUiThread(() =>
            {
                titleView.Text = title;
            });
        }

        public void SetTime(string time)
        {
            var textField = FindViewById<TextView>(Resource.Id.detailTimer);
            (Context as Activity)?.RunOnUiThread(() =>
            {
                textField.Text = time;
            });
        }
    }
}