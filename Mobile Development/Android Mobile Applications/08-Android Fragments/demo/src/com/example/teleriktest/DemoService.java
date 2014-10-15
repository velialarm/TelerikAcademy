package com.example.teleriktest;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.util.Log;

public class DemoService extends Service
{
	private static final String TAG = DemoService.class.getSimpleName();
	private static final int Delay = 3000;
	private boolean isStarted = false;
		
	private Updater update;
	
	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		Log.d(TAG, "onBind");
		return null;
		
	}
	
	@Override
	public void onCreate() {
		// TODO Auto-generated method stub
		super.onCreate();
		update = new Updater();
		Log.d(TAG, "onCreate");
	}
	
	@Override
	public synchronized void onStart(Intent intent, int startId) {
		// TODO Auto-generated method stub
		super.onStart(intent, startId);
		Log.d(TAG, "onStart");
		if(update != null && isStarted == false) {
			update.start();
			isStarted = true;
		}
		
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		// TODO Auto-generated method stub
		Log.d(TAG, "onStartCommand");
		return super.onStartCommand(intent, flags, startId);
		
	}
	
	@Override
	public void onDestroy() {
		// TODO Auto-generated method stub
		Log.d(TAG, "onDestroy");
		super.onDestroy();
		update.interrupt();
		
		update = null;
	}
	
	class Updater extends Thread
	{
		
		public Updater()
		{
			super("Update Thread");
		}
		
		@Override
		public void run() {
			
			// TODO Auto-generated method stub
			super.run();
			while (true) {
				try {
					Log.d(TAG,"I am workin'g");
	                Thread.sleep(Delay);
                } catch (InterruptedException e) {
	                // TODO Auto-generated catch block
	                e.printStackTrace();
	                isStarted = false;
                }
			}
		}
		
	}
	
}
