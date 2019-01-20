using System;
using System.Timers;
using Portable.Controllers.Detail.Interfaces;
using Portable.Repositories;

namespace Portable.Controllers.Detail
{
    public class DetailController : IDetailController
    {
        public event Action OnReturn;
        
        private IDetailView _view;

        private double _redTick;
        private double _greenTick;
        private double _blueTick;

        private double _red = 255;
        private double _green = 255;
        private double _blue = 255;

        private double _time = 0;

        public DetailController(IDetailView view)
        {
            _view = view ?? throw new ArgumentException(nameof(view));
        }

        public void SetData(string id)
        {
            var showingTime = TimingRepository.GetInstance().ShowingTime;
            var data = DataRepository.GetInstance().GetDataById(id);

            _view.SetColor((int)_red, (int)_green, (int)_blue);
            _view.SetTitle(data.Name);

            _redTick = (255 - data.Red) * 1.0 / (showingTime * 60);
            _greenTick = (255 - data.Green) * 1.0 / (showingTime * 60);
            _blueTick = (255 - data.Blue) * 1.0 / (showingTime * 60);
            int tick = 17;

            Timer timerChange = new Timer(tick);
            Timer timerEnd = new Timer(showingTime * 1020);

            timerChange.AutoReset = true;
            timerChange.Elapsed += NextChange;

            timerEnd.Elapsed += GoBack;

            timerChange.Start();
            timerEnd.Start();
        }

        private void GoBack(object sender, ElapsedEventArgs e)
        {
            OnReturn?.Invoke();
        }

        private void NextChange(object sender, ElapsedEventArgs e)
        {
            _red -= _redTick;
            _green -= _greenTick;
            _blue -= _blueTick;

            _time += 17 * 1.0 / 1000;
            var txt = string.Format("{0:N2}", _time);

            _view.SetColor((int)_red, (int)_green, (int)_blue);
            _view.SetTime(txt);
        }
    }
}