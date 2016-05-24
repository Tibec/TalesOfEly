using UnityEngine;
using System.Collections;
using System;

public class PlayerData
{
	private static PlayerData instance;

	public enum AvatarType {
		Male,
		Female
	}

	private AvatarType charGender;

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

	public void SetAvatar(AvatarType t)
	{
		charGender = t;
	}

	public void Disp()
	{
		Debug.Log ("Prout");
	}
}
