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
		// Géré mouvement de la camera

		// Utiliser Vector3.Lerp (+ d'info dans le code de smoothcamera.cs)

	}

	public void Play(String map, int id)
	{
		Type item = this.GetType ();
		MethodInfo function = item.GetMethod ("play_" + map + "_" + id, BindingFlags.NonPublic | BindingFlags.Instance);
		if (function == null)
			Debug.Log ("ptr null ");
		function.Invoke (this, null);
	}

	private void TeleportCamera(int x, int y)
	{
        SmoothCamera script = camera.GetComponent<SmoothCamera>();
        Vector2 now = new Vector2(x, y);
        camera.transform.position = now;
        script.follow.position = now;

    }

	private void MoveCamera(int x, int y, float speed)
	{

	}

	private void CameraFollow(Manipulable.Character c, float speed)
	{
       SmoothCamera script = camera.GetComponent<SmoothCamera>();
        script.follow.position = GetGameObjectByCharacter(c).transform.position;
	}

    private GameObject GetGameObjectByCharacter(Manipulable.Character c)
    {
        foreach(GameObject g in chars)
        {
            if(g.GetComponent<Manipulable.Character>() == c)
            {
                return g;
            }
        }
        throw new Exception("Le personnage n'existe pas");
    }

    private Manipulable.Character GetCharacterByName(string name)
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
		Manipulable.Character c = GetCharacterByName ("ElyM");
		c.TeleportTo (15, 5);
		c.RunTo (15, 15, Orientation.UP);
		c.RunTo (35, 15, Orientation.RIGTH);

	}
}