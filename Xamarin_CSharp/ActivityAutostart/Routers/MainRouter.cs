using System;
using ActivityAutostart.Activities;
using Android.App;
using Android.Content;
using Portable.Controllers.Main.Interfaces;

namespace ActivityAutostart.Routers
{
    public class MainRouter : IMainRouter
    {
        private readonly WeakReference<Context> _context;

        public MainRouter(WeakReference<Context> context)
        {
            _context = context;
        }

        public void GoToDetail(string id)
        {
            if (_context.TryGetTarget(out var context))
            {
                var intent = new Intent(context, typeof(DetailActivity));
                intent.PutExtra(Constants.Id, id);
                (context as Activity)?.StartActivityForResult(intent, Constants.RequestCodeDetail);
            }
        }

        public void GoToSelector()
        {
            if (_context.TryGetTarget(out var context))
            {
                var intent = new Intent(context, typeof(SelectorActivity));
                (context as Activity)?.StartActivityForResult(intent, Constants.RequestCodeSelector);
            }
        }
    }
}