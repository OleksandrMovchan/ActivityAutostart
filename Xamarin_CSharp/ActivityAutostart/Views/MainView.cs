using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Widget;
using Portable.Controllers.Main.Interfaces;
using Portable.Data;
using Portable.Repositories;

namespace ActivityAutostart.Views
{
    [Register("ActivityAutostart.Views.MainView")]
    public class MainView : ConstraintLayout, IMainView
    {
        public event Action OnButtonClicked;

        public MainView(Context context) : base(context)
        {
            Init();
        }

        public MainView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public MainView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            var inflater = ((Activity)Context).LayoutInflater;
            inflater.Inflate(Resource.Layout.view_main, this, true);
            InitButtons();
            DataRepository.GetInstance().AllData = MockDataCollection.GetCollection();
        }

        private void InitButtons()
        {
            var btn = FindViewById<Button>(Resource.Id.mainBtnStart);
            if (!btn.HasOnClickListeners)
            {
                btn.Click += BtnClicked;
            }
        }

        private void BtnClicked(object s, EventArgs e)
        {
            OnButtonClicked?.Invoke();
        }
    }
}