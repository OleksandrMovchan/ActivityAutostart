package com.example.activityautostart.selector

import com.example.activityautostart.data.DataModel
import com.example.activityautostart.data.DataRepository
import com.example.activityautostart.data.SomeData
import com.example.activityautostart.data.TimingRepository

class SelectorListController(private val view: SelectorView): SelectorController {

    private val dataModelsList = arrayListOf<DataModel>()

    override fun init() {
        val dataList = DataRepository.getAllData()
        val checkedData = DataRepository.getCheckedData()
        for (data in dataList) {
            dataModelsList.add(DataModel(data.id, checkedData.contains(data)))
        }
        view.setAllData(dataModelsList)
    }

    override fun changeSelection(id: String) {
        val checkedData: ArrayList<SomeData> = DataRepository.getCheckedData()
        for (model in dataModelsList) {
            if (model.id == id && model.isChecked) {
                model.isChecked = false
                val currentData = findData(model.id)
                if (currentData != null) {
                    checkedData.remove(currentData)
                }
                break
            } else if (model.id == id && !model.isChecked) {
                model.isChecked = true
                val currentData = findData(model.id)
                if (currentData != null) {
                    checkedData.add(currentData)
                }
                break
            }
        }
        DataRepository.setCheckedData(checkedData)
        view.setAllData(dataModelsList)
    }

    override fun changeShowingTime(time: Int) {
        TimingRepository.setShowingTime(time)
    }

    override fun changeInterval(interval: Int) {
        TimingRepository.setInterval(interval)
    }

    private fun findData(id: String): SomeData? {
        val dataList = DataRepository.getAllData()
        for (data in dataList) {
            if (data.id == id) return data
        }
        return null
    }
}