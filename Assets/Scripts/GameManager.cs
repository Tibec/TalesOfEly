using UnityEngine;
using System.Collections;
using System;
using Entities;

public class GameManager : MonoBehaviour {

	public Camera cam;

	private Scene scene;
	private int step;
	// Use this for initialization
	void Start () {
		// Retrieve game data
		//data = PlayerData.Instance;

		// Get current scene content
		scene = StoryManager.Instance.GetScene(PlayerData.Instance.Scene);
		step = 0;
		// Move the camera far away
		cam.transform.position = new Vector3 (-50, -50, -10);

		LoadCharacters ();
	}

	// Update is called once per frame
	void Update () {
		if (scene != null) {
			if (scene.Map != UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name) {
				UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (scene.Map);
			}
		}
	}

	void LoadCharacters() {
		/*Character[] chars;// = scene.GetCharacters ();
		foreach(Character c in chars)
		{
			// Instanciate everyprefabs
		}*/
	}
}
