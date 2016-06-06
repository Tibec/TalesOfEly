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
	string mcName;

	// Accesseur des composants de la scene;
	private tk2dCamera camera;
	private List<GameObject> chars;

	private bool finished;
	public bool InProgress {
		get { return !finished; }
	}


	public void Init(tk2dCamera _camera, List<GameObject> _chars)
	{
		camera = _camera;
		chars = _chars;
		mcName = PlayerData.Instance.Avatar == PlayerData.AvatarType.Male ? "ElyM" : "ElyF";

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
		Debug.Log ("Starting cinematics : " + map + "_" + id);
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

	private void play_colline_1()
	{
        AudioMgr.instance.PlayMusic("CollineAmb");
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
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

		timer = 20f;
	}

	private void play_colline_2() {
		AudioMgr.instance.PlayMusic("CollineAmb");
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.clearMoves ();
		c.TeleportTo (13, 21);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);
		c.WalkTo (13, 22, Orientation.DOWN);
		c.TeleportTo (13, 21);
		c.WalkTo (13, 22, Orientation.DOWN);
		c.TeleportTo (13, 21);
		c.WalkTo (13, 22, Orientation.DOWN);
		c.TeleportTo (13, 21);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);
		timer = 0f;
	}	
	private void play_colline_3() {
		timer = 0f;
	}
	private void play_colline_4() {
		timer = 0f;
	}
	private void play_colline_5() {
		timer = 0f;
	}
	private void play_colline_6() {
		timer = 0f;
	}
	private void play_colline_7() {
		timer = 0f;
	}
	private void play_colline_8() {
		timer = 0f;
	}
	private void play_colline_9() {
		//AudioMgr.instance.PlayMusic("CollineAmb");
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.TeleportTo (31, 9);
		camera.GetComponent<SmoothCamera> ().TeleportTo (31, 9);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		Manipulable.Character ch1, ch2, ch3, ch4, ch5;
		ch1 = GetCharacterByName ( "Chevre1");
		ch2 = GetCharacterByName ( "Chevre2");
		ch3 = GetCharacterByName ( "Chevre3");
		ch4 = GetCharacterByName ( "Chevre4");
		ch5 = GetCharacterByName ( "Chevre5");

		ch1.TeleportTo (32, 9);
		ch2.TeleportTo (33, 9);
		ch3.TeleportTo (27, 20);
		ch4.TeleportTo (17, 14);
		ch5.TeleportTo (18, 22);

		ch1.RunTo (45, 9, Orientation.RIGHT	);

		ch2.RunTo (45, 9, Orientation.RIGHT);

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
	private void play_colline_10() {
		timer = 0f;
	}
	private void play_colline_11() {
		timer = 0f;
	}
	private void play_colline_12() {
		timer = 0f;
	}
	private void play_colline_13() {
		Manipulable.Character c;
		c = GetCharacterByName (mcName);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		c.RunTo (43, 9, Orientation.RIGHT	);
		c.RunTo (43, 0, Orientation.DOWN);
		timer = 5f;
	}
	private void play_colline_14() {
		timer = 0f;
	}
	private void play_chemincolvil_1() {
		//AudioMgr.instance.PlayMusic("CollineAmb");
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.TeleportTo (12, 1);
		camera.GetComponent<SmoothCamera> ().TeleportTo (12,1);
		Manipulable.Character ch1, ch2, ch3, ch4, ch5;
		ch1 = GetCharacterByName ( "Chevre1");
		ch2 = GetCharacterByName ( "Chevre2");
		ch3 = GetCharacterByName ( "Chevre3");
		ch4 = GetCharacterByName ( "Chevre4");
		ch5 = GetCharacterByName ( "Chevre5");
		ch1.TeleportTo (11, 1);
		ch2.TeleportTo (13, 1);
		ch3.TeleportTo (11, 0);
		ch4.TeleportTo (12, 0);
		ch5.TeleportTo (13, 0);
		c.WalkTo (12, 40, Orientation.UP);
		ch1.WalkTo (11, 40, Orientation.UP);
		ch2.WalkTo (13, 40, Orientation.UP);
		ch3.WalkTo (11, 40, Orientation.UP);
		ch4.WalkTo (12, 40, Orientation.UP);
		ch5.WalkTo (13, 40, Orientation.UP);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);


		timer = 28f;
	}
	private void play_chemincolvil_2() {
		//AudioMgr.instance.PlayMusic("CollineAmb");
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.TeleportTo (24, 18);
		camera.GetComponent<SmoothCamera> ().TeleportTo (12,1);
		Manipulable.Character ch1, ch2, ch3, ch4, ch5;
		ch1 = GetCharacterByName ( "Chevre1");
		ch2 = GetCharacterByName ( "Chevre2");
		ch1.TeleportTo (25, 18);
		ch2.TeleportTo (26, 18);
		c.WalkTo (12, 18, Orientation.LEFT);
		c.WalkTo (12, 40, Orientation.UP);
		ch1.WalkTo (12, 18, Orientation.LEFT);
		ch1.WalkTo (11, 40, Orientation.UP);
		ch2.WalkTo (12, 18, Orientation.LEFT);
		ch2.WalkTo (13, 40, Orientation.UP);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);


		timer = 20f;
	}
	private void play_village_1() {
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.TeleportTo (10, 2);
		camera.GetComponent<SmoothCamera> ().TeleportTo (10,2);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		Manipulable.Character m;
		m = GetCharacterByName ( "Mother");
		m.TeleportTo (25, 18);
		m.LookTo (Orientation.DOWN);
		c.WalkTo (10, 14, Orientation.UP);
		c.WalkTo (20, 16, Orientation.RIGHT);
		c.LookTo (Orientation.UP);

		timer = 15f;
	}
	private void play_foret_1() {
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		c.TeleportTo (0	, 32);
		c.RunTo (24, 32, Orientation.RIGHT);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		timer = 5f;
	}
	private void play_foret_2() {
		Manipulable.Character c;
		c = GetCharacterByName ( mcName);
		Manipulable.Character ch = GetCharacterByName ("Chevre1");
		c.RunTo (24, 16, Orientation.DOWN);
		c.RunTo (64, 8, Orientation.RIGHT);
		c.RunTo (64, 38, Orientation.UP	);
		ch.TeleportTo (62, 40);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);

		timer = 20f;
	}
	private void play_foret_3() {
		timer = 0f;
	}
	private void play_foret_4() {
		timer = 0f;
	}
	private void play_noir_1() {
		camera.GetComponent<SmoothCamera> ().TeleportTo (-3, -1);
		Manipulable.Character m, e;
		m = GetCharacterByName ("Mother");
		e = GetCharacterByName (mcName);
		m.TeleportTo (-5, 0);
		m.LookTo (Orientation.RIGHT);
		e.TeleportTo (0, 0);
		e.LookTo (Orientation.LEFT);

		timer = 0f;
	}
	private void play_noir_2() {
		timer = 0f;
	}
	private void play_noir_3() {
		timer = 0f;
	}
	private void play_noir_4() {
		timer = 0f;
	}
	private void play_noir_5() {
		timer = 0f;
	}
	private void play_finale_1() {
		camera.GetComponent<SmoothCamera> ().TeleportTo (44, 2);
		Manipulable.Character c, b, g;
		c = GetCharacterByName ( mcName);
		b = GetCharacterByName ( "Badman");
		g = GetCharacterByName ( "grandpere");
		b.TeleportTo (20, 41);
		c.TeleportTo (18, 38);
		g.TeleportTo (22, 38);
		camera.GetComponent<SmoothCamera> ().TeleportTo (20, 40);

		timer = 0f;
	}
	private void play_finale_2() {
		timer = 0f;
	}

	private void play_village_elfes_1(){
		camera.GetComponent<SmoothCamera> ().TeleportTo (44, 2);
		Manipulable.Character c, e1, e2, e3, e4;
		c = GetCharacterByName ( mcName);
		e1 = GetCharacterByName ("Elfe");
		e2 = GetCharacterByName ("Elfe2");
		e3= GetCharacterByName ("Elfe3");
		e4 = GetCharacterByName ("Elfe4");
		c.TeleportTo (44, 4);
		c.LookTo (Orientation.UP);
		e1.TeleportTo (43, 7);
		e2.TeleportTo (40, 7);
		e3.TeleportTo (41, 10);
		e4.TeleportTo (42, 10);
		e1.RunTo (43, 6, Orientation.DOWN);
		e2.RunTo (40, 6, Orientation.DOWN);
		e3.RunTo (41, 9, Orientation.DOWN);
		e4.RunTo (42, 9, Orientation.DOWN);
		camera.GetComponent<SmoothCamera> ().FollowTo (c.transform);
		timer = 0f;
	}
}