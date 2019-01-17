package com.example.activityautostart.selector

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.ViewGroup
import com.example.activityautostart.data.DataModel
import com.example.movch.activityautostart.R

class SelectorAdapter(private val controller: SelectorController): RecyclerView.Adapter<SelectorHolder>() {
    private var dataList: List<DataModel> = listOf()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): SelectorHolder =
        SelectorHolder(LayoutInflater.from(parent.context)
            .inflate(R.layout.holder_selector_card, parent, false), controller)

    override fun getItemCount(): Int = dataList.size

    override fun onBindViewHolder(holder: SelectorHolder, position: Int) {
        val dataModel = dataList[position]
        holder.init(dataModel)
    }

    fun setAllData(dataList: List<DataModel>) {
        this.dataList = dataList
    }
}