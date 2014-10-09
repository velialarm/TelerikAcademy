package com.example.testproj;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class OtherActivity extends Activity implements View.OnClickListener
{
	TextView txtData;
	Button btnPrev;
	Context context = this;
	
	private void initializeComponent() {
		txtData = (TextView) this.findViewById(R.id.txtData);
		btnPrev = (Button) this.findViewById(R.id.btnBack);
		
	}
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.other_activity);
		//Intent dataFromOtherActivity = this.getIntent();
		Bundle bundle = this.getIntent().getExtras();
		bundle.getString("NUMBER");
		Customer someKind = (Customer)bundle.getParcelable("CLASS");
		Toast.makeText(context, String.valueOf(someKind.Age), Toast.LENGTH_SHORT)
        .show();
	}

	@Override
    public void onClick(View v) {
	    // TODO Auto-generated method stub
	   
    }
}
