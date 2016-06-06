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

		timer = 2f;
	}

	private void play_colline_2() {
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
		timer = 0f;
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
		timer = 0f;
	}
	private void play_colline_14() {
		timer = 0f;
	}
	private void play_chemincolvil_1() {
		timer = 0f;
	}
	private void play_chemincolvil_2() {
		timer = 0f;
	}
	private void play_village_1() {
		timer = 0f;
	}
	private void play_foret_1() {
		timer = 0f;
	}
	private void play_foret_2() {
		timer = 0f;
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
		timer = 0f;
	}
	private void play_finale_2() {
		timer = 0f;
	}
}