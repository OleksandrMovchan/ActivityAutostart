using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Portable.Data;

namespace ActivityAutostart.Recycler
{
    public class SelectorHolder : RecyclerView.ViewHolder
    {
        public event Action<string> OnSelectorClick;
        private string _id;

        public SelectorHolder(View itemView) : base(itemView)
        {
        }

        public void Init(DataModel dataModel)
        {
            var selectorMark = ItemView.FindViewById<ImageView>(Resource.Id.selectorMark);
            selectorMark.Visibility = dataModel.IsChecked ? ViewStates.Visible : ViewStates.Invisible;

            var selectorTextView = ItemView.FindViewById<TextView>(Resource.Id.selectorCheckText);
            selectorTextView.Text = dataModel.Id;

            _id = dataModel.Id;

            var holderLl = ItemView.FindViewById<LinearLayout>(Resource.Id.selectorCheckBox);
            if (!holderLl.HasOnClickListeners)
            {
                holderLl.Click += SelectorClicked;
            }
        }

        private void SelectorClicked(object sender, EventArgs e)
        {
            OnSelectorClick?.Invoke(_id);
        }
    }
}