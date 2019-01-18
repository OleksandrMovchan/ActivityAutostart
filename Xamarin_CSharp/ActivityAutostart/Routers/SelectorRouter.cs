﻿using System;
using Android.App;
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
            if (_context.TryGetTarget(out var context) && context is Activity act)
            {
                act.RunOnUiThread(() =>
                {
                    act.OnBackPressed();
                });
            }
        }
    }
}