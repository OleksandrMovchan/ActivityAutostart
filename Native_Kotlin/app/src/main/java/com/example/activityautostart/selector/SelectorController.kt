package com.example.activityautostart.selector

interface SelectorController {
    fun init()
    fun changeSelection(id: String)
    fun changeShowingTime(time: Int)
    fun changeInterval(interval: Int)
}