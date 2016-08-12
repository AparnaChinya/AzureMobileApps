package com.example.apchin.mobileapps;

/**
 * Created by apchin on 8/1/2016.
 */
public class TodoItem {
    public String Id;

    @com.google.gson.annotations.SerializedName("text")
    public String Text;

    @com.google.gson.annotations.SerializedName("complete")
    private boolean mComplete;

    @com.google.gson.annotations.SerializedName("text")
    public String mText;

    public String getText() {
        return mText;
    }
    public void setComplete(boolean complete) {
        mComplete = complete;
    }
    public boolean isComplete() {
        return mComplete;
    }

}
