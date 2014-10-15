package com.example.teleriktest;

import android.annotation.SuppressLint;
import android.app.Fragment;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

@SuppressLint("NewApi")
public class FragmentOne extends Fragment
{
	public FragmentOne(Context context) {
		//((MainActivity)context).showToast();
	}

	private void initializeComponents(View v) {
		final TextView txtToChange = (TextView)v.findViewById(R.id.textView1);
		txtToChange.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				txtToChange.setText("I was clicked,yeah !");
				
			}
		});
	}

	@Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
	    // TODO Auto-generated method stub
		View v = inflater.inflate(R.layout.fragment_one, container, false);
		initializeComponents(v);
	    return v;
    }
	
}
