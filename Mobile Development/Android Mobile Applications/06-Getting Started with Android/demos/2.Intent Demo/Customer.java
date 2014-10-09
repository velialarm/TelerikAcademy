package com.example.testproj;

import android.os.Parcel;
import android.os.Parcelable;

public class Customer implements Parcelable
{
	
	private String firstName, lastName, Address;
	int Age;
	
	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}
	
	public Customer(String name, String nameTwo, String adress, int age)
	{
		this.firstName = name;
		this.lastName = nameTwo;
		this.Address = adress;
		this.Age = age;
	}
	
	public static final Parcelable.Creator<Customer> CREATOR = new Parcelable.Creator<Customer>() {
		public Customer createFromParcel(Parcel in) {
			return new Customer(in);
		}
		
		public Customer[] newArray(int size) {
			return new Customer[size];
		}
	};
	
	public Customer(Parcel in)
	{
		readFromParcel(in);
	}
	
	@Override
	public void writeToParcel(Parcel dest, int flags) {
		// TODO Auto-generated method stub
		dest.writeString(firstName);
		dest.writeString(lastName);
		dest.writeString(Address);
		dest.writeInt(Age);
	}
	
	private void readFromParcel(Parcel in) {
		firstName = in.readString();
		lastName = in.readString();
		Address = in.readString();
		Age = in.readInt();
	}
}
