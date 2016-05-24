using UnityEngine;
using System.Collections;

public class CircularRotation : MonoBehaviour {
	public float angle = 0.005f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float s = Mathf.Sin (angle), c = Mathf.Cos (angle); 
		Vector3 pivot = Vector3.zero;
		Vector3 now = this.transform.position;
		Vector3 after = new Vector3();
		after.z = now.z;
		now -= pivot;

		after.x = now.x * c - now.y * s;
		after.y = now.x * s + now.y * c;

		Debug.Log (after);

		after += pivot;
		this.transform.position = after;
	}
}
