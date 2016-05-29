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
	private int currentScene;

	public AvatarType Avatar {
		get {return charGender;}
		set { charGender = value; } 
	}

	public int Scene {
		get { return currentScene; }
		set { currentScene = value; }
	}

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


	public void Disp()
	{
		Debug.Log ("Prout");
	}
}
