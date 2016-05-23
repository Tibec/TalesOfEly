using UnityEngine;
using System.Collections;
using System;

public class PlayerData
{
	private static PlayerData instance;

	private String _a = "Fuuu";
	private PlayerData() {}

	public static PlayerData Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new PlayerData();
			}
			return instance;
		}
	}

	public void setBidule(String a)
	{
		_a = a;
	}

	public void Disp()
	{
		Debug.Log (_a);
	}
}
