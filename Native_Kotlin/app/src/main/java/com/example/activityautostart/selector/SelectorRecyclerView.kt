package com.example.activityautostart.selector

import android.app.Activity
import android.content.Context
import android.support.v7.widget.RecyclerView
import android.util.AttributeSet
import com.example.activityautostart.data.DataModel

class SelectorRecyclerView @JvmOverloads constructor(
    context: Context, attrs: AttributeSet? = null, defStyleAttr: Int = 0
) : RecyclerView(context, attrs, defStyleAttr), SelectorView {

    override fun setAllData(data: List<DataModel>) {

        if (adapter is SelectorAdapter) {
            val selectorAdapter: SelectorAdapter = adapter as SelectorAdapter
            selectorAdapter.setAllData(data)
            (context as Activity).runOnUiThread{ adapter?.notifyDataSetChanged() }
        }
    }

}