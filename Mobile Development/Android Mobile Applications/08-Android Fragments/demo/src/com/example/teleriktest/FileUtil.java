package com.example.teleriktest;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

import android.content.Context;
import android.os.Environment;
import android.util.Log;

public class FileUtil
{
	static String state = Environment.getExternalStorageState();
	
	public static String readDataFromFile(Context context, String fileName) {
		FileInputStream fis = null;
		String readString = null;
		if (isSDcardAvailable()) {
			try {
				fis = context.openFileInput(fileName);
				InputStreamReader isr = new InputStreamReader(fis);
				// READ STRING OF UNKNOWN LENGTH
				StringBuilder sb = new StringBuilder();
				char[] inputBuffer = new char[2048];
				int l;
				// FILL BUFFER WITH DATA
				while ((l = isr.read(inputBuffer)) != -1) {
					sb.append(inputBuffer, 0, l);
				}
				// CONVERT BYTES TO STRING
				readString = sb.toString();
				fis.close();
			} catch (Exception e) {
				
			} finally {
				if (fis != null) {
					fis = null;
				}
			}
			return readString;
		}
		return null;
	}
	
	public static void writeDataToFile(Context context, String data) {
		if (isSDcardAvailable()) {
			try {
				OutputStreamWriter outputStreamWriter = new OutputStreamWriter(
				        context.openFileOutput("config.txt",
				                Context.MODE_PRIVATE));
				outputStreamWriter.write(data);
				outputStreamWriter.close();
			} catch (IOException e) {
				Log.e("Exception", "File write failed: " + e.toString());
			}
		}
	}
	
	private static boolean isSDcardAvailable() {
		if (state.equals(Environment.MEDIA_MOUNTED)) {
			return true;
		}
		return false;
	}
}
