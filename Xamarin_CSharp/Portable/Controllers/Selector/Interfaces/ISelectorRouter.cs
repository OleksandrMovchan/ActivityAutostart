using System;

namespace Portable.Controllers.Selector.Interfaces
{
    public interface ISelectorRouter
    {
        event Action OnReturn;
        void GoBack();
    }
}