package com.example.activityautostart.activities

import android.content.Intent
import android.graphics.drawable.GradientDrawable
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import com.example.activityautostart.constants.Constants
import com.example.activityautostart.data.DataCollection
import com.example.activityautostart.data.DataRepository
import com.example.activityautostart.data.TimingRepository
import com.example.movch.activityautostart.R
import kotlinx.android.synthetic.main.activity_main.*
import java.util.*

class MainActivity : AppCompatActivity() {

    private var counter = 0
    private var isTimerStarted = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    override fun onResume() {
        super.onResume()
        initButton()

        DataRepository.setAllData(DataCollection().getCollection())
    }

    private fun initButton() {
        mainBtnStart.setOnClickListener { buttonClicked() }
//        runOnUiThread {
//            mainBtnStart.background.mutate()
//            val drawer = mainBtnStart.background as GradientDrawable
//            drawer.setStroke(2, getColor(R.color.textColorMain))
//        }
    }

    private fun buttonClicked() {
        mainBtnStart.isClickable = false
        val i = Intent(this, SelectorActivity::class.java)
        startActivityForResult(i, Constants.requestCodeSelector)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        when (requestCode) {
            Constants.requestCodeSelector -> startTimer()
            Constants.requestCodeDetail -> startShowing()
            else -> return
        }
    }

    private fun startTimer() {
        if (isTimerStarted) return

        val interval = TimingRepository.getInterval()
        val timer = Timer()
        val timerTask = object : TimerTask() {
            override fun run() {
                isTimerStarted = true
                startShowing()
            }
        }

        timer.schedule(timerTask, 0, interval * 60 * 1000L)
    }

    private fun startShowing() {
        val checkedData = DataRepository.getCheckedData()

        if (counter >= checkedData.size) {
            counter = 0
            return
        }

        val currentData = checkedData[counter]
        val i = Intent(this, DetailActivity::class.java)
        i.putExtra(Constants.id, currentData.id)
        counter++
        startActivityForResult(i, Constants.requestCodeDetail)
    }
}