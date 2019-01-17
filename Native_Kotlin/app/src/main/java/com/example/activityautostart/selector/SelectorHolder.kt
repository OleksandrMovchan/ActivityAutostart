package com.example.activityautostart.selector

import android.support.v7.widget.RecyclerView
import android.view.View
import android.widget.TextView
import com.example.activityautostart.data.DataModel
import com.example.movch.activityautostart.R
import kotlinx.android.synthetic.main.holder_selector_card.view.*

class SelectorHolder(itemView: View, private val controller: SelectorController) : RecyclerView.ViewHolder(itemView) {
    fun init(dataModel: DataModel) {
        if (dataModel.isChecked) itemView.selectorMark.visibility = View.VISIBLE
        else itemView.selectorMark.visibility = View.INVISIBLE

        val selectorTextView: TextView = itemView.findViewById(R.id.selectorCheckText)
        selectorTextView.text = dataModel.id


        if (!itemView.selectorCheckBox.hasOnClickListeners()) {
            itemView.selectorCheckBox.setOnClickListener { controller.changeSelection(selectorTextView.text.toString()) }
        }
    }
}