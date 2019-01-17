namespace Portable.Repositories
{
    public class TimingRepository
    {
        #region SingletonInit

        private static TimingRepository _instance;

        public static TimingRepository GetInstance()
        {
            return _instance ?? (_instance = new TimingRepository());
        }

        private TimingRepository()
        {
        }

        #endregion

        private int _showingTime;
        private int _interval;

        public int ShowingTime
        {
            get => _showingTime;
            set => _showingTime = value;
        }

        public int Interval
        {
            get => _interval;
            set => _interval = value;
        }
    }
}