package com.example.teleriktest;

import java.io.IOException;
import java.io.InputStream;

import android.annotation.SuppressLint;
import android.app.ActionBar;
import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.Intent;
import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.os.Messenger;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;

@SuppressLint("NewApi")
public class MainActivity extends Activity
{
	
	Context context = this;
	final String TAG = "FIRSTAPPLICATION";
	ImageView mario, android;
	ActionBar actionBar;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.fragment_main);
		// Toast.makeText(this, String.valueOf(R.string.hello_world),
		// Toast.LENGTH_SHORT).show();
//		String hello = String.valueOf(this.getResources()
//		        .getString(R.bool.test));
//		actionBar = this.getActionBar();
//		actionBar.setHomeButtonEnabled(true);
//		actionBar.setDisplayHomeAsUpEnabled(true);
//		actionBar.setDisplayShowCustomEnabled(true);
//		
//		actionBar.setCustomView(R.layout.custom_actionbar);
//		actionBar.hide();			
				
	}
	
	public void showToast() {
		Toast.makeText(this, "Test", Toast.LENGTH_SHORT).show();
	}
	
	public void show_popup(View view) {
		// PopupMenu popup = new PopupMenu(MainActivity.this,view);
		// popup.setOnMenuItemClickListener(this);
		// popup.inflate(R.layout.popup_layout);
		// popup.show();
		
		//actionBar.show();
		
				
		this.startService(new Intent(MainActivity.this,DemoService.class));
	}
	
	private Bitmap getBitmapFromAssets(String fileName) {
		
		AssetManager assetManager = this.getAssets();
		InputStream istr = null;
		
		try {
			istr = assetManager.open(fileName);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		Bitmap fromAsset = BitmapFactory.decodeStream(istr);
		
		return fromAsset;
	}
	
	public void stop_service(View view) {
		this.stopService(new Intent(MainActivity.this,DemoService.class));
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	public void selectFrag(View view) {
		Fragment fr;
		
		if (view == findViewById(R.id.button2)) {
			fr = new FragmentTwo();
			
		} else {
			fr = new FragmentOne(this.getApplicationContext());
		}				
		FragmentManager fm = getFragmentManager();
		FragmentTransaction fragmentTransaction = fm.beginTransaction();
		fragmentTransaction.replace(R.id.fragment_place, fr);			
		fragmentTransaction.commit();		
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
	
	@Override
	public boolean onMenuItemSelected(int featureId, MenuItem item) {
		int test = 5;
		return true;
	}
	
	@Override
	public void onStart() {
		super.onStart();
		Log.d(TAG, "onStart");
	}
	
	@Override
	public void onResume() {
		super.onResume();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onPause() {
		super.onPause();
		Log.d(TAG, "onPause");
	}
	
	@Override
	public void onStop() {
		super.onStop();
		Log.d(TAG, "onStop");
	}
	
	@Override
	public void onDestroy() {
		super.onDestroy();
		Log.d(TAG, "onDestroy");
	}
	
}
