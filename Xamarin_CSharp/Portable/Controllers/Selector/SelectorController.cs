using System;
using System.Collections.Generic;
using Portable.Controllers.Selector.Interfaces;
using Portable.Data;
using Portable.Repositories;

namespace Portable.Controllers.Selector
{
    public class SelectorController : ISelectorController
    {
        private readonly List<DataModel> _dataModelsList;
        private ISelectorView _view;
        private ISelectorRouter _router;
        private bool _isSubscribed = false;

        public event Action OnReturn;

        public SelectorController(ISelectorView view, ISelectorRouter router)
        {
            _view = view ?? throw new ArgumentException(nameof(view));
            _router = router ?? throw new ArgumentException(nameof(router));
            _dataModelsList = new List<DataModel>();
        }
        
        public void Init()
        {
            List<SomeData> dataList = DataRepository.GetInstance().AllData;
            List<SomeData> checkedData = DataRepository.GetInstance().CheckedData;

            foreach (var data in dataList)
            {
                _dataModelsList.Add(new DataModel(data.Id, checkedData.Contains(data)));
            }
            _view.SetAllData(_dataModelsList);
        }

        public void Subscribe()
        {
            if (_isSubscribed) return;
            _view.Subscribe();
            _view.OnButtonClick += GoBack;
            _view.OnItemClick += ChangeSelection;
            _isSubscribed = true;
        }
        
        public void Unsubscribe()
        {
            if (!_isSubscribed) return;
            _view.Unsubscribe();
            _view.OnButtonClick -= GoBack;
            _view.OnItemClick -= ChangeSelection;
            _isSubscribed = false;
        }

        public void ChangeSelection(string id)
        {
            List<SomeData> checkedData = DataRepository.GetInstance().CheckedData;
            foreach (var model in _dataModelsList) 
            {
                if (model.Id == id && model.IsChecked)
                {
                    model.IsChecked = false;
                    var currentData = FindData(model.Id);
                    if (currentData != null)
                    {
                        checkedData.Remove(currentData);
                    }
                    break;
                }

                if (model.Id == id && !model.IsChecked)
                {
                    model.IsChecked = true;
                    var currentData = FindData(model.Id);
                    if (currentData != null)
                    {
                        checkedData.Add(currentData);
                    }
                    break;
                }
            }
            DataRepository.GetInstance().CheckedData = checkedData;
            _view.SetAllData(_dataModelsList);
        }

        public void ChangeShowingTime(int time)
        {
            TimingRepository.GetInstance().ShowingTime = time;
        }

        public void ChangeInterval(int interval)
        {
            TimingRepository.GetInstance().Interval = interval;
        }

        private SomeData FindData(string id)
        {
            List<SomeData> dataList = DataRepository.GetInstance().AllData;
            foreach (var data in dataList)
            {
                if (data.Id == id)
                {
                    return data;
                }
            }

            return null;
        }

        private void GoBack()
        {
            OnReturn?.Invoke();
            _router.GoBack();
        }
    }
}