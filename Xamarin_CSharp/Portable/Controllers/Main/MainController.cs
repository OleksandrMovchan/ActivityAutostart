﻿using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Portable.Controllers.Main.Interfaces;
using Portable.Data;
using Portable.Repositories;
using Timer = System.Timers.Timer;

namespace Portable.Controllers.Main
{
    public class MainController : IMainController
    {
        private bool _isTimerStarted = false;
        private bool _isSubscribed = false;

        private IMainView _view;
        private IMainRouter _router;

        public MainController(IMainView view, IMainRouter router)
        {
            _view = view;
            _router = router;
        }

        public void Subscribe()
        {
            if (_isSubscribed) return;
            _view.OnButtonClicked += GoToSelector;
            _isSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!_isSubscribed) return;
            _view.OnButtonClicked -= GoToSelector;
            _isSubscribed = false;
        }

        private void GoToSelector()
        {
            _router.GoToSelector();
        }

        public void RunTimer()
        {
            if (_isTimerStarted)
            {
                return;
            }

            int interval = TimingRepository.GetInstance().Interval;
            Timer timer = new Timer(interval * 1000 * 60);
            timer.Elapsed += NextInterval;
            timer.Start();

            ShowNext();
        }

        private void NextInterval(object sender, ElapsedEventArgs e)
        {
            ShowNext();
        }

        public void ShowNext()
        {
            List<SomeData> checkedData = DataRepository.GetInstance().CheckedData;

            foreach (var data in checkedData)
            {
                _router.GoToDetail(data.Id);
            }
        }
    }
}