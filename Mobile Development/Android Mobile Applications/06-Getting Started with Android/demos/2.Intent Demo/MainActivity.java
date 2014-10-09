package com.example.testproj;

import java.util.ArrayList;
import java.util.List;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ResolveInfo;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

@SuppressLint("NewApi")
public class MainActivity extends Activity implements View.OnClickListener
{
	final String TAG = "APPLICATION";
	EditText editName;
	final Context context = this;
	private Button btnOne, btnTwo;
	final int OTHER_ACTIVITY_CODE = 100;
	final int IMAGE_SELECTOR = 100;
	private ListView list;
	private ArrayList<String> data;
	CustomListViewAdapter adapter;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		list = (ListView) this.findViewById(R.id.listView1);
				
		adapter = new CustomListViewAdapter(context,
		        R.layout.item_info,new int[]{R.drawable.ic_launcher});
		adapter.add("Telerik is cool place to learn !");
		list.setAdapter(adapter);		
		list.setOnItemClickListener(new OnItemClickListener() {
			
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
			        int position, long id) {
				// TODO Auto-generated method stub
				adapter.add("DataNewOnClick");
				adapter.notifyDataSetChanged();
//				Toast.makeText(context, String.valueOf(adapter.getItem(position)), Toast.LENGTH_SHORT)
//				        .show();
			}
			
		});
		// btnOne = (Button) this.findViewById(R.id.button1);
		// btnTwo = (Button) this.findViewById(R.id.btnTextChanger);
		// btnOne.setOnClickListener(this);
		// btnTwo.setOnClickListener(this);
		// Log.d(TAG, "onCreate");
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	public void selectImage() {
		Intent imageIntent = new Intent();
		imageIntent.setType("image/*");
		imageIntent.setAction(Intent.ACTION_GET_CONTENT);
		imageIntent.addCategory(Intent.CATEGORY_OPENABLE);
		this.startActivityForResult(imageIntent, IMAGE_SELECTOR);
	}
	
	public void shareLinkWithFacebook() {
		String urlToShare = "http://www.telerik.com/platform";
		Intent facebookIntent = new Intent();
		facebookIntent.setType(Intent.ACTION_SEND);
		facebookIntent.putExtra(Intent.EXTRA_TEXT, urlToShare);
		
		boolean isFacebookAvailable = false;
		
		List<ResolveInfo> match = this.getPackageManager()
		        .queryIntentActivities(facebookIntent, 0);
		for (ResolveInfo info : match) {
			if (info.activityInfo.packageName.toLowerCase().startsWith(
			        "com.facebook.katana")) {
				facebookIntent.setPackage(info.activityInfo.packageName);
				isFacebookAvailable = true;
				break;
			}
			
		}
		
		if (!isFacebookAvailable) {
			String shareUrl = "https://www.facebook.com/sharer/sharer.php?u="
			        + urlToShare;
			facebookIntent = new Intent(Intent.ACTION_VIEW,
			        Uri.parse(urlToShare));
			this.startActivity(facebookIntent);
		}
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
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onStop() {
		super.onStop();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onDestroy() {
		super.onDestroy();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onClick(View v) {
		// if (v.getId() == R.id.button1) {
		// shareLinkWithFacebook();
		// selectImage();
		// Intent intent = new Intent(MainActivity.this,
		// OtherActivity.class);
		// Customer pesho = new Customer("Pesho", "Peshev", "Unknows", 20);
		// intent.putExtra("CLASS", pesho);
		// this.startActivity(intent);
		// }
		// if (v.getId() == R.id.btnTextChanger) {
		// Toast.makeText(context, "Button Text Changer", Toast.LENGTH_SHORT)
		// .show();
		// }
		
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		Toast.makeText(context, String.valueOf(requestCode), Toast.LENGTH_SHORT)
		        .show();
	}
	
}
