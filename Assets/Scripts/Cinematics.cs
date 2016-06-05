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

	class Instruction {

	};

	// Tuning options
	private float camSpeed;

	//
	int camMode; // 0 = immobile ; 1 = en déplacement ; 2 = follow
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

	Queue<Instruction> ins;

	public void Init(tk2dCamera _camera, List<GameObject> _chars, AudioMgr mgr)
	{
		camera = _camera;
		chars = _chars;
		camMode = 0;
		ins = new Queue<Instruction> ();
	}

	public void Update()
	{
		if (ins.Count == 0 ) {
			finished = true;
			return;
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
		Debug.Log ("Début cinematique");
		Manipulable.Character c = GetCharacterByName ( "ElyM");
		c.TeleportTo (15, 5);
		c.WalkTo (15, 15, Orientation.UP);
		c.WalkTo (35, 15, Orientation.RIGTH);
		camera.ZoomFactor = 3;
		camera.transform.position = new Vector3 (15, 0, -50);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

	}
}