//Simple Smooth follow 2D camera that locks to a tile map!
//Written by Adam Corrow
using UnityEngine;

[RequireComponent (typeof (tk2dCamera))]
public class SmoothCamera : MonoBehaviour {
	public Transform follow; //Set in unity, you can tag it and use Gameobject.FindWithTag...
	public float smoothing = 10;
	public tk2dTileMap map; //Same goes for the tile map, tag it and find it, or assign it manually in the Unity UI
	private tk2dCamera tkcamera; //this is a required component, so we can use GetComponent safely below.
	public 	int tileSize = 16; //the size of your tiles.
	public 	float adjustement = 1.3f; //correction
	public  float cameraPrecision = 200f;

	void Start () {
		tkcamera = GetComponent<tk2dCamera>();
	}
	void FixedUpdate () {
		Debug.Log (tkcamera.ScreenExtents.height);
		Vector3 p0 = map.data.tileOrigin; //Get the lower left extent of the tile map.
		Vector3 p1 = new Vector3(p0.x + map.width, p0.y + map.height, 0.0f); //Now get the upper right extent of the tile map.
		float w = tkcamera.ScreenExtents.width ; //Get the width of the screen. If you have no intention to zoom the camera, move these
		float h = tkcamera.ScreenExtents.height; //into the Start() method so that you only get them once. If you zoom in and out though, you want to read it every time.
		transform.position = RoundCoordinate(Vector3.Lerp(
			transform.position, //Lerping from this position
			new Vector3(//to this new position that we are creating
				//first the X coords of the Vector3,
				Mathf.Clamp(//use Mathf.Clamp to limit the X coord of the Vector
					follow.position.x, //This is our position
					p0.x +w/adjustement,//this is the lower limit of the clamp, it will be the lower left of our TileMap, plus half the width of the screen
					p1.x-w/adjustement),//same with the upper extent of the x, only SUBTRACT half the width of the screen                   
				Mathf.Clamp(follow.position.y,//Same clamp on the Y, but using Height...
					p0.y+h/adjustement,
					p1.y-h/adjustement ),
				-10 //Z axis coord of the vector3 we are lerping toward. Maybe you don't need this set to -10...
			), smoothing * Time.deltaTime)); //Apply our smoothing factor to the lerp..
	}

	public Vector3 RoundCoordinate(Vector3 coord)
	{
		coord.x = Mathf.Round(coord.x  * cameraPrecision) / cameraPrecision;
		coord.y = Mathf.Round(coord.y  * cameraPrecision) / cameraPrecision;
		return coord;
	}
}