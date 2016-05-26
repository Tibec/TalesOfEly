using UnityEngine;
using System.Collections;
using System;
/*
public class GameManager : MonoBehaviour {

	public Camera cam;

	private GameScene scene;

	// Use this for initialization
	void Start () {
		// Retrieve game data
		data = PlayerData.Instance;

		// Get current scene content
		scene = Story.GetScene(PlayerData.Instance.currentScene);

		// Move the camera far away
		cam.transform.position = new Vector3 (-50, -50, -10);

		LoadCharacters ();
	}

	// Update is called once per frame
	void Update () {
		if (scene.Map != UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name) {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (scene.map);
		}
	}

	void LoadCharacters() {
		Character[] chars;// = scene.GetCharacters ();
		foreach(Character c in chars)
		{
			// Instanciate everyprefabs
		}
	}
}
*/