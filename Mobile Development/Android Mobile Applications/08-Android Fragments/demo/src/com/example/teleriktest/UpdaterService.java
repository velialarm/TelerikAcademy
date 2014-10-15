package com.example.teleriktest;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.os.Message;
import android.os.Messenger;
import android.os.RemoteException;
import android.util.Log;

public class UpdaterService extends Service
{
	private static final String TAG = UpdaterService.class.getSimpleName();
	private Updater updater;
	private boolean isRunning = false;	
		
	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		return null;
	}
		

	@Override
	public synchronized void onStart(Intent intent, int startId) {
		// TODO Auto-generated method stub
		super.onStart(intent, startId);
		Log.d(TAG, "OnStart()");
		if (!isRunning) {
			updater.start();
			this.isRunning = true;
		}
	}
	
	@Override
	public void onCreate() {
		// TODO Auto-generated method stub
		super.onCreate();
		
		updater = new Updater();
		
		Log.d(TAG, "OnCreate()");
	}
	
	@Override
	public void onDestroy() {
		// TODO Auto-generated method stub
		super.onDestroy();
		Log.d(TAG, "OnDestroy()");
		if (this.isRunning) {
			updater.interrupt();
		}
		updater = null;
	}
	
	class Updater extends Thread
	{
		static final long DELAY = 3000;
		
		public Updater()
		{
			super("Updater");
		}
		
		@Override
		public void run() {
			while (true) {
				Log.d(TAG, "Updater run'ing");			
				try {
					Thread.sleep(DELAY);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					isRunning = false;
					e.printStackTrace();
				}
			}
			
		}
		
	}
	
}
