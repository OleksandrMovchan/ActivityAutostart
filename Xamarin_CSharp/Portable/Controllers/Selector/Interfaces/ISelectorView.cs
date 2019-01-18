using System;
using System.Collections.Generic;
using Portable.Data;

namespace Portable.Controllers.Selector.Interfaces
{
    public interface ISelectorView
    {
        event Action<string> OnItemClick;
        event Action OnButtonClick;

        void Subscribe();
        void Unsubscribe();
        void SetAllData(List<DataModel> data);
    }
}