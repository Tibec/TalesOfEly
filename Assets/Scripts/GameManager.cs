﻿using UnityEngine;
using System.Collections;
using System;
using Entities;

public class GameManager : MonoBehaviour {

	public Camera cam;
	public GameObject dialogUI;
	public DialogManager dialogUiScript;

	private Scene scene;
	private int step;
	private bool stepInProgress;
	// Use this for initialization
	void Start () {
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		if (scene != null) {
			if (scene.Map != UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name) {
				UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (scene.Map);

			}

			if (stepInProgress == false) {
				stepInProgress = true;
				// On doit demarre la nouvelle étape de la scene
				if (step == scene.Content.Count) {
					PlayerData.Instance.Scene++;
					Reset ();
				}
				Content c = scene.Content [step];
				if (c.get_type () == content_type.DIALOG) {
					// Load Dialog
					foreach (Part p in c.Parts) {
						Character charData = StoryManager.Instance.GetCharacter (p.Char);
						dialogUiScript.AddDialog (p.Text, charData.Name, "noface");
					}
					// Show up the UI
					dialogUI.SetActive (true);

				} else if (c.get_type () == content_type.CHOICE) {
				
				} else { // (c.get_type () == content_type.CINEMATIC) 
				
				}
					
			} else {
				// check if the current scene item is finished 
				Content c = scene.Content [step];
				if (c.get_type () == content_type.DIALOG) {
					// Show up the UI
					if (dialogUiScript.IsFinished ()) {
						dialogUI.SetActive (false);
						stepInProgress = false;
						step++;
					}
				} else if (c.get_type () == content_type.CHOICE) {

				} else { // (c.get_type () == content_type.CINEMATIC) 

				}

			}
								
		}
	}

	void Reset()
	{
		// Get current scene content
		try {
			scene = StoryManager.Instance.GetScene(PlayerData.Instance.Scene);
		} catch(Exception e) {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("Menu");
		}
		step = 0;
		stepInProgress = false;
		dialogUI.SetActive(false);

		// Move the camera far away
		cam.transform.position = new Vector3 (-50, -50, -50);

		LoadCharacters ();
	}

	void LoadCharacters() {
		/* Character[] chars;// = scene.GetCharacters ();
		foreach(Character c in chars)
		{
			// Instanciate everyprefabs
		}*/
	}
}
