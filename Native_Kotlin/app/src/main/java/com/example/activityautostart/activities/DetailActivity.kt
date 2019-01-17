package com.example.activityautostart.activities

import android.graphics.Color
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import com.example.activityautostart.constants.Constants
import com.example.activityautostart.data.DataRepository
import com.example.activityautostart.data.TimingRepository
import com.example.movch.activityautostart.R
import kotlinx.android.synthetic.main.activity_detail.*
import java.util.*

class DetailActivity : AppCompatActivity() {

    private var id: String = ""

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail)
    }

    override fun onResume() {
        super.onResume()

        id = intent.getStringExtra(Constants.id)
        setData()
    }

    private fun setData() {
        val showingTime = TimingRepository.getShowingTime()
        val data = DataRepository.getDataById(id)

        detailLayout.setBackgroundColor(Color.WHITE)

        var red = 255.0
        var green = 255.0
        var blue = 255.0

        val redTick = (255 - data.red) * 1.0 / (showingTime * 60)
        val greenTick = (255 - data.green) * 1.0 / (showingTime * 60)
        val blueTick = (255 - data.blue) * 1.0 / (showingTime * 60)

        var currentTime = 0.0

        runOnUiThread {
            detailContent.text = data.name
            detailTimer.text = currentTime.toString()

            detailContent.setTextColor(getColor(R.color.textDark))
        }


        val activity = this

        val innerTimer = Timer()
        val innerTimerTask = object : TimerTask() {
            override fun run() {
                red -= redTick
                green -= greenTick
                blue -= blueTick

                activity.runOnUiThread {
                    detailLayout.setBackgroundColor(
                        Color.rgb(
                            red.toInt(),
                            green.toInt(),
                            blue.toInt()
                        )
                    )
                }

                currentTime += 17 * 1.0 / 1000
                activity.runOnUiThread {
                    detailTimer.text = String.format("%.2f", currentTime)
                    val middleValue = (red + green + blue) / 3
                    val color: Int = when {
                        middleValue < 130 -> getColor(R.color.textLight)
                        middleValue < 195 -> getColor(R.color.textColorMain)
                        else -> getColor(R.color.textDark)
                    }

                    detailTimer.setTextColor(color)
                    detailContent.setTextColor(color)
                }
            }
        }
        innerTimer.schedule(innerTimerTask, 0, 17)

        val outerTimer = Timer()
        val outerTimerTask = object : TimerTask() {
            override fun run() {
                activity.runOnUiThread { onBackPressed() }
            }
        }
        outerTimer.schedule(outerTimerTask, showingTime * 1020L)
    }
}
