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
	bool move;

	void Start () {
		tkcamera = GetComponent<tk2dCamera>();
		move = false;
	}
	void FixedUpdate () {
		if (!move)
			return;
		Vector3 p0 = map.data.tileOrigin; //Get the lower left extent of the tile map.
		Vector3 p1 = new Vector3(p0.x + map.width, p0.y + map.height, 0.0f); //Now get the upper right extent of the tile map.
		Debug.Log(follow);
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
				-50 //Z axis coord of the vector3 we are lerping toward. Maybe you don't need this set to -10...
			), smoothing * Time.deltaTime)); //Apply our smoothing factor to the lerp..
	}

	public void MoveTo(int x, int y)
	{
		move = true;
		follow.position = new Vector3 (x, y, -50);
	}

	public void TeleportTo(int x, int y)
	{
		move = false;
		follow.position = new Vector3 (x, y, -50);
		tkcamera.transform.position = new Vector3 (x, y, -50);
	}

	public void FollowTo(Transform c)
	{
		move = true;
		follow = c;
	}

	private Vector3 RoundCoordinate(Vector3 o)
	{
		int p = 100;
		Vector3 r = new Vector3 (o.x, o.y, o.z);
		r.x = Mathf.Round (r.x * p) / p;
		r.y = Mathf.Round (r.y* p) / p;
		return r;
	}
}