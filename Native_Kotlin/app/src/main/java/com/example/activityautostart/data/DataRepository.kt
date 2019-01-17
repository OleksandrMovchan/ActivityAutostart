package com.example.activityautostart.data

object DataRepository {
    private var checkedData: ArrayList<SomeData> = arrayListOf()
    private var allData: ArrayList<SomeData> = arrayListOf()

    fun getCheckedData(): ArrayList<SomeData> = checkedData

    fun setCheckedData(checkedData: ArrayList<SomeData>) {
        this.checkedData = checkedData
    }

    fun setCheckedData(checkedIds: Set<String>) {
        checkedData = arrayListOf()

        for (data in allData) {
            for (id in checkedIds) {
                if (data.id == id) {
                    checkedData.add(data)
                    continue
                }
            }
        }
    }

    fun getAllData(): ArrayList<SomeData> = allData

    fun setAllData(allData: ArrayList<SomeData>) {
        this.allData = allData
    }

    fun getDataById(id: String): SomeData {
        for (data in allData) {
            if (data.id == id) return data
        }
        return SomeData("", "", 255, 255, 255)
    }
}