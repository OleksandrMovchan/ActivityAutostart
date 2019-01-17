using System.Collections.Generic;
using Portable.Data;

namespace Portable.Repositories
{
    public class DataRepository
    {
        #region SingletonInit

        private static DataRepository _instance;

        public static DataRepository GetInstance()
        {
            return _instance ?? (_instance = new DataRepository());
        }

        private DataRepository()
        {
        }

        #endregion

        private List<SomeData> _allData;
        private List<SomeData> _checkedData;

        public List<SomeData> AllData
        {
            get => _allData;
            set => _allData = value;
        }

        public List<SomeData> CheckedData
        {
            get => _checkedData;
            set => _checkedData = value;
        }

        public void SetCheckedData(List<string> checkedIds)
        {
            _checkedData = new List<SomeData>();

            foreach (var data in _allData)
            {
                foreach (var id in checkedIds)
                {
                    if (data.Id == id)
                    {
                        _checkedData.Add(data);
                        continue;
                    }
                }
            }
        }

        public SomeData GetDataById(string id)
        {
            foreach (var data in _allData)
            {
                if (data.Id == id)
                    return data;
            }
            return new SomeData("", "", 255, 255, 255);
        } 
    }
}