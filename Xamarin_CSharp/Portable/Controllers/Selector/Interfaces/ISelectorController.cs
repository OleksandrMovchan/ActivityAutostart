using System;

namespace Portable.Controllers.Selector.Interfaces
{
    public interface ISelectorController
    {
        event Action OnReturn;

        void Init();
        void Subscribe();
        void Unsubscribe();
        void ChangeSelection(string id);
        void ChangeShowingTime(int time);
        void ChangeInterval(int interval);
    }
}