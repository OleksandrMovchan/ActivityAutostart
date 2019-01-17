package com.example.activityautostart.data

data class SomeData(
    val id: String,
    val name: String,
    val red: Int,
    val green: Int,
    val blue: Int
)

data class DataModel(
    val id: String,
    var isChecked: Boolean
)