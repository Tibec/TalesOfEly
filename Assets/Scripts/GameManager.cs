using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Entities;

public class GameManager : MonoBehaviour {

    public tk2dCamera cam; 
    public GameObject dialogUI;
	public GameObject choiceUI;
	public DialogManager dialogUiScript;
	public ChoiceManager choiceUiScript;

	public List<GameObject> chars;

	private Scene scene;
	private int step;
	private bool stepInProgress;

	private Cinematics cinematicMgr;

	//
	public void Awake()
	{
		
	}

	// Use this for initialization
	public void Start () {
		Reset ();
		LoadCharacters ();
	}

	// Update is called once per frame
	public void Update () {
		if (scene == null) {
			return;
		}


		if (scene.Map != UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name) {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (scene.Map);

		}

		if (stepInProgress == false) {
			stepInProgress = true;
			if (step > scene.Content.Count) { // On doit demarre la nouvelle étape de la scene
				Reset ();
				return;
			} else if (step == scene.Content.Count) { // On affiche les choix
				if (scene.Choices == null) { // Alors on est a la fin :(
					UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("credit");
				} else {
					dialogUI.SetActive (false);
					choiceUiScript.SetChoices (scene.Choices [0].get_text (), scene.Choices [1].get_text ());
					choiceUI.SetActive (true);
				}
			} else { // Traitement de l'étape
				Content c = scene.Content [step];
				if (c.get_type () == content_type.DIALOG) {
					// Load Dialog
					foreach (Part p in c.Parts) {
						Character charData = StoryManager.Instance.GetCharacter (p.Char);
						dialogUiScript.AddDialog (p.Text, charData.Name, "noface");
					}
					// Show up the UI
					dialogUI.SetActive (true);

				} else { // (c.get_type () == content_type.CINEMATIC) 
					cinematicMgr = new Cinematics();
					cinematicMgr.Init(cam, chars, null );
				}
			}
				
		} else {
			// check if we ask for choices
			if (step == scene.Content.Count) {
				Debug.Log (choiceUiScript.GetChoice ());
				if (choiceUiScript.GetChoice () != -1) {
					PlayerData.Instance.Scene = scene.Choices [choiceUiScript.GetChoice ()].get_next_scene ();
					step++;
					stepInProgress = false;
					choiceUI.SetActive (false);
				}
			} else {
				// check if the current scene item is finished 
				Content c = scene.Content [step];
				if (c.get_type () == content_type.DIALOG) {
					// Show up the UI
					if (dialogUiScript.IsFinished ()) {
						dialogUI.SetActive (false);
						dialogUiScript.Reset ();
						step++;
					}
				} else { // (c.get_type () == content_type.CINEMATIC) 
					cinematicMgr.Update();
					if(!cinematicMgr.InProgress){
						stepInProgress = false;
						step++;
					}
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


		Debug.Log ("Debut de la scene : " + scene.Id);
	}

	void LoadCharacters() {
		chars = new List<GameObject> ();

		chars.Add (Resources.Load ("ElyM") as GameObject);
		chars.Add (Resources.Load ("ElyF") as GameObject);
		chars.Add (Resources.Load ("Chevre") as GameObject);
		chars.Add (Resources.Load ("Mother") as GameObject);

		foreach (GameObject c in chars){
			Instantiate (c);
			c.GetComponents<Character> ();
		}
	}
}
