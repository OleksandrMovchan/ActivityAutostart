using System;
using Android.App;
using Android.Content;
using Portable.Controllers.Detail.Interfaces;

namespace ActivityAutostart.Routers
{
    public class DetailRouter : IDetailRouter
    {
        private WeakReference<Context> _context;

        public DetailRouter(WeakReference<Context> context)
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