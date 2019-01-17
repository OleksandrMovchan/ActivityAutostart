using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Portable.Data;

namespace ActivityAutostart.Recycler
{
    public class SelectorAdapter : RecyclerView.Adapter
    {
        public event Action<string> OnSelectorClick;

        private List<DataModel> _dataList;

        public override int ItemCount => _dataList?.Count ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is SelectorHolder selectorHolder)
            {
                selectorHolder.OnSelectorClick -= SelectorClicked;
                selectorHolder.Init(_dataList[position]);
                selectorHolder.OnSelectorClick += SelectorClicked;
            }
        }
        
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new SelectorHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.holder_selector, parent, false));
        }

        public void SetAllData(List<DataModel> dataList)
        {
            _dataList = dataList;
        }

        private void SelectorClicked(string id)
        {
            OnSelectorClick?.Invoke(id);
        }
    }
}