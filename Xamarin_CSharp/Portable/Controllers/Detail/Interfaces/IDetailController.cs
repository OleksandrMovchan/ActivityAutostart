using System;

namespace Portable.Controllers.Detail.Interfaces
{
    public interface IDetailController
    {
        event Action OnReturn;

        void SetData(string id);
    }
}