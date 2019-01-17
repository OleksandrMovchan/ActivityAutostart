using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Portable.Data;

namespace ActivityAutostart.Recycler
{
    [Register("ActivityAutostart.Recycler.SelectorRecyclerView")]
    public class SelectorRecyclerView : RecyclerView
    {
        public SelectorRecyclerView(Context context) : base(context)
        {
        }

        public SelectorRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SelectorRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public void SetAllData(List<DataModel> data)
        {
            if (GetAdapter() is SelectorAdapter adapter)
            {
                adapter.SetAllData(data);
                (Context as Activity)?.RunOnUiThread(adapter.NotifyDataSetChanged);
            }
        }
    }
}