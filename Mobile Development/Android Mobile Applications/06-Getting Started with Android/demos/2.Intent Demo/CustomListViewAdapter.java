package com.example.testproj;

import android.content.Context;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class CustomListViewAdapter extends ArrayAdapter<String>
{
	
	static class ViewHolderItem
	{
		ImageView img;
		TextView txtBig;
		TextView txtSmall;
	}
	
	Context context;
	int[] resources;
	
	public CustomListViewAdapter(Context context, int resource, int[] imgResources)
	{
		super(context, resource);
		this.context = context;
		this.resources = imgResources;
	}
	
	@Override
	public View getView(int position, View view, ViewGroup parent) {
		
		ViewHolderItem holder;
		
		if (view == null) {
			holder =  new ViewHolderItem();
			LayoutInflater inflater = (LayoutInflater) context
			        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.item_info, parent, false);
			holder.img = (ImageView) view.findViewById(R.id.imageView1);
			holder.txtBig =(TextView) view.findViewById(R.id.textView1);
			holder.txtSmall = (TextView) view.findViewById(R.id.textView2);
			view.setTag(holder);
		} else {
			holder = (ViewHolderItem)view.getTag();
		}
				
		holder.img.setImageResource(this.resources[position]);
		holder.txtBig.setText("You changed me !");
		holder.txtSmall.setText(Html.fromHtml("<small><small>Test</small></small>"));
		return view;
		
	}
	
}
