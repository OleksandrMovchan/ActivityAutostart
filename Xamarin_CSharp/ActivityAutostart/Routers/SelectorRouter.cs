using System;
using Android.Content;
using Portable.Controllers.Selector.Interfaces;

namespace ActivityAutostart.Routers
{
    public class SelectorRouter : ISelectorRouter
    {
        public event Action OnReturn;

        private WeakReference<Context> _context;

        public SelectorRouter(WeakReference<Context> context)
        {
            _context = context;
        }

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }
    }
}