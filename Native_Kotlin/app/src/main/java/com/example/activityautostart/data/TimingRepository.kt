package com.example.activityautostart.data

object TimingRepository {
    private var showingTime = 0
    private var interval = 0

    fun getShowingTime() : Int = showingTime

    fun setShowingTime(scanningTime: Int) {
        this.showingTime = scanningTime
    }

    fun getInterval() : Int = interval

    fun setInterval(interval: Int) {
        this.interval = interval
    }
}