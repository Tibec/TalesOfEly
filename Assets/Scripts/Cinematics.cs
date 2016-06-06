using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Manipulable;
using SoundManager;

public class Cinematics 
{   
	float timer;

	// Tuning options
	private float camSpeed;

	//
	Vector2 destination;
	Manipulable.Character target;

	// Accesseur des composants de la scene;
	private tk2dCamera camera;
	private List<GameObject> chars;
	private AudioMgr audioMgr;

	private bool finished;
	public bool InProgress {
		get { return !finished; }
	}


	public void Init(tk2dCamera _camera, List<GameObject> _chars, AudioMgr mgr)
	{
		camera = _camera;
		chars = _chars;
	}

	public void Update()
	{
		if (timer <= 0) {
			finished = true;
			return;
		} else {
			timer -= Time.deltaTime;
		}
		

	}

	public void Play(String map, int id)
	{
		Type item = this.GetType ();
		MethodInfo function = item.GetMethod ("play_" + map + "_" + id, BindingFlags.NonPublic | BindingFlags.Instance);
		if (function == null)
			Debug.Log ("ptr null ");
		function.Invoke (this, null);
	}


	private Manipulable.Character GetCharacterByName( string name)
	{
		foreach (GameObject g in chars) {
			if (g.name == name) {
				return g.GetComponent<Manipulable.Character> ();
			}
		}

		throw new Exception("Le personnage n'existe pas");
	}

	private void play_village_1()
	{
		/*
		 	Camera.SetPosition(x, y)
		 	Camera.Move(x, y)
			Char1.Move(A, B, WALK/RUN/TELEPORT);
			PlaySound("mname");
			PlayEffect("sfx");
			StopSound();

		*/
	}

	private void play_colline_1()
	{
		Manipulable.Character c;
		if(PlayerData.Instance.Avatar == PlayerData.AvatarType.Male)
			c = GetCharacterByName ( "ElyM");
		else 
			c = GetCharacterByName ( "ElyF");	
		c.TeleportTo (30, 23);
		camera.GetComponent<SmoothCamera> ().TeleportTo (30, 23);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		c.WalkTo (30, 16, Orientation.DOWN);
		c.WalkTo (15, 14, Orientation.LEFT);
		c.WalkTo (15, 17, Orientation.UP);
		c.WalkTo (13, 19, Orientation.UP);
		c.WalkTo (13, 21, Orientation.UP);
		c.WalkTo (12, 22, Orientation.UP);
		c.WalkTo (14, 22, Orientation.RIGHT);
		c.WalkTo (13, 21, Orientation.DOWN);

		Manipulable.Character ch1, ch2, ch3, ch4, ch5;
		ch1 = GetCharacterByName ( "Chevre1");
		ch2 = GetCharacterByName ( "Chevre2");
		ch3 = GetCharacterByName ( "Chevre3");
		ch4 = GetCharacterByName ( "Chevre4");
		ch5 = GetCharacterByName ( "Chevre5");

		ch1.TeleportTo (16, 16);
		ch2.TeleportTo (18, 17);
		ch3.TeleportTo (27, 20);
		ch4.TeleportTo (17, 14);
		ch5.TeleportTo (18, 22);

		ch1.WalkTo (16, 25, Orientation.UP);
		ch1.WalkTo (16, 16, Orientation.DOWN);

		ch2.WalkTo (27, 17, Orientation.RIGHT);
		ch2.WalkTo (18, 17, Orientation.LEFT);

		ch3.WalkTo (18, 20, Orientation.LEFT);
		ch3.WalkTo (18, 15, Orientation.RIGHT);

		ch4.WalkTo (10, 14, Orientation.LEFT);
		ch4.WalkTo (17, 14, Orientation.RIGHT);
		ch4.WalkTo (10, 14, Orientation.LEFT);
		ch4.WalkTo (17, 14, Orientation.RIGHT);

		ch5.WalkTo (18, 15, Orientation.DOWN);
		ch5.WalkTo (25, 14, Orientation.RIGHT);

		timer = 2f;
	}
}