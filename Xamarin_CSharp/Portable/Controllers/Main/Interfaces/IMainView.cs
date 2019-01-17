using System;

namespace Portable.Controllers.Main.Interfaces
{
    public interface IMainView
    {
        event Action OnButtonClicked;
    }
}