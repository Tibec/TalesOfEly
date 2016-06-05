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
	// Tuning options
	private float camSpeed;
	private float playerSpeed;


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
		// Run subroutines
		//foreach (Character c in chars) {
			//c.Update ();
		//}

	}

	public void Play(String map, int id)
	{
		Type item = this.GetType ();
		MethodInfo function = item.GetMethod("play_"+map+"_"+id);
		function.Invoke (this, null);
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
		
	}
}