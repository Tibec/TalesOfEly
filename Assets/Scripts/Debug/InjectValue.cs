using UnityEngine;
using System.Collections;

public class InjectValue : MonoBehaviour {

	public int StartScene;

	// Use this for initialization
	void Start () {
		PlayerData.Instance.Scene = StartScene;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("colline");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
