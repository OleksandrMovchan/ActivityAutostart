using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Portable.Controllers.Selector.Interfaces;
using Portable.Data;

namespace ActivityAutostart.Views
{
    [Register("ActivityAutostart.Views.SelectorView")]
    public class SelectorView : ConstraintLayout, ISelectorView
    {
        public event Action<string> OnItemClick;
        public event Action OnButtonClick;

        public SelectorView(Context context) : base(context)
        {
        }

        public SelectorView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SelectorView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public void SetAllData(List<DataModel> data)
        {
            throw new NotImplementedException();
        }
    }
}