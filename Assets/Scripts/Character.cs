using UnityEngine;
using System.Collections;

namespace Manipulable {
	
public class Character : MonoBehaviour {

	private Transform currentPoint;
	private tk2dSpriteAnimator animation;

	//

	private Vector2 destination;

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		// Should we move ?
		//if (currentPoint.position != destination) {
			// Faire calcul de déplacement selon vitese
		//}


	}

	public void RunTo(int x, int y)
	{
		// Start animation run

		MoveTo (x, y);
	}

	public void WalkTo(int x, int y)
	{
		// Start animation walk

		MoveTo (x, y);
	}

	private void MoveTo(int x, int y)
	{
		destination.x = x;
		destination.y = y;
	}
}

}