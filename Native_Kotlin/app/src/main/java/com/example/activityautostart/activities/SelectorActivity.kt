package com.example.activityautostart.activities

import android.app.Activity
import android.content.Context
import android.graphics.drawable.GradientDrawable
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.support.v7.widget.LinearLayoutManager
import android.text.Editable
import com.example.activityautostart.data.DataRepository
import com.example.activityautostart.data.TimingRepository
import com.example.activityautostart.selector.SelectorAdapter
import com.example.activityautostart.selector.SelectorListController
import com.example.movch.activityautostart.R
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.activity_selector.*

class SelectorActivity : AppCompatActivity() {

    private val preferencesName = "SETTINGS_DEFAULT"
    private val dataKey = "data"
    private val intervalKey = "interval"
    private val showingKey = "showing"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_selector)
    }

    override fun onResume() {
        super.onResume()

        getFromShared()

        val controller = SelectorListController(selectorRecycler)
        selectorRecycler.adapter = SelectorAdapter(controller)
        selectorRecycler.layoutManager = LinearLayoutManager(this, 1, false)

        controller.init()

        this.setResult(Activity.RESULT_OK, intent)
        initButton()
    }

    private fun initButton() {
        selectorBtnConfirm.setOnClickListener {
            setIntoShared()
            this.onBackPressed()
        }

//        runOnUiThread {
//            mainBtnStart.background.mutate()
//            val drawer = mainBtnStart.background as GradientDrawable
//            drawer.setStroke(2, getColor(R.color.textColorMain))
//        }
    }

    private fun setIntoShared() {
        val editor = getSharedPreferences(preferencesName, Context.MODE_PRIVATE).edit()
        val set = HashSet<String>()
        for (data in DataRepository.getCheckedData())
            set.add(data.id)

        TimingRepository.setInterval(selectorInterval.text.toString().toInt())
        TimingRepository.setShowingTime(selectorTime.text.toString().toInt())

        editor.putStringSet(dataKey, set)
        editor.putInt(intervalKey, selectorInterval.text.toString().toInt())
        editor.putInt(showingKey, selectorTime.text.toString().toInt())
        editor.apply()
    }

    private fun getFromShared() {
        val preferences = getSharedPreferences(preferencesName, Context.MODE_PRIVATE)
        val dataIds = preferences.getStringSet(dataKey, HashSet<String>())
        val interval = preferences.getInt(intervalKey, 240)
        val showingTime = preferences.getInt(showingKey, 30)

        DataRepository.setCheckedData(dataIds)
        selectorInterval.text = Editable.Factory.getInstance().newEditable(interval.toString())
        selectorTime.text = Editable.Factory.getInstance().newEditable(showingTime.toString())
    }
}
