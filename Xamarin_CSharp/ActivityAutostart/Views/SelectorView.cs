using System;
using System.Collections.Generic;
using ActivityAutostart.Recycler;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;
using Portable.Controllers.Selector.Interfaces;
using Portable.Data;
using Portable.Repositories;

namespace ActivityAutostart.Views
{
    [Register("ActivityAutostart.Views.SelectorView")]
    public class SelectorView : ConstraintLayout, ISelectorView
    {
        public event Action<string> OnItemClick;
        public event Action OnButtonClick;

        private SelectorRecyclerView _recycler;
        private Button _btnConfirm;

        public SelectorView(Context context) : base(context)
        {
            Init();
        }

        public SelectorView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public SelectorView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            var inflater = ((Activity)Context).LayoutInflater;
            inflater.Inflate(Resource.Layout.view_selector, this, true);
            InitRecycler();
            InitButtons();
        }

        public void Subscribe()
        {
            _btnConfirm.Click += ButtonClicked;
            _recycler.Subscribe();
            _recycler.OnSelectorClick += SelectorClicked;
        }

        private void SelectorClicked(string id)
        {
            OnItemClick?.Invoke(id);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke();
        }

        public void Unsubscribe()
        {
            _btnConfirm.Click -= ButtonClicked;
            _recycler.Unsubscribe();
            _recycler.OnSelectorClick -= SelectorClicked;
        }

        private void InitRecycler()
        {
            _recycler = FindViewById<SelectorRecyclerView>(Resource.Id.selectorRecycler);
            _recycler.SetAdapter(new SelectorAdapter());
            _recycler.SetLayoutManager(new LinearLayoutManager(Context, 1, false));
        }

        private void InitButtons()
        {
            _btnConfirm = FindViewById<Button>(Resource.Id.selectorBtnConfirm);
        }

        public void SetAllData(List<DataModel> data)
        {
            _recycler.SetAllData(data);
        }
    }
}