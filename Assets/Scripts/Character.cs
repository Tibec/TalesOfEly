using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manipulable {

	public enum Orientation {
		UP, 
		DOWN, 
		LEFT,
		RIGTH
	};

	public struct Checkpoint {
		public Vector3 dest;
		public Orientation o;
	};



	public class Character : MonoBehaviour {
		private float walkSpeed = 0.03f;
		private float runSpeed = 0.1f;
		private Transform transform;
		private tk2dSpriteAnimator anims;

		private Queue<Checkpoint>paths;

		bool moving;
		bool running;
		private bool init = false;
		public bool Initialized {
			get { return init; }
		}


		// Use this for initialization
		public void Awake () {
			Debug.Log ("Character initialised : "+name);
			transform = GetComponent<Transform> ();
			anims = GetComponent<tk2dSpriteAnimator> ();
			paths = new Queue<Checkpoint> ();
			init = true;
			moving = false;
		}
		
		// Update is called once per frame
		public void Update () {
			// Should we move ?
			if (paths.Count > 0) {
				if (!moving) {
					string animName = BuildAnimName("Walk", paths.Peek().o);
					Debug.Log ("playing : " + animName);
					anims.Play(animName);
					if(running)
						anims.ClipFps = 10.0f;
				}

				if (paths.Peek ().dest != transform.position) {
					// Si on a pas atteint on continue d'avance

					Vector3 np = transform.position;
					float speed = running ? runSpeed : walkSpeed;
					// Faire calcul de déplacement selon vitesse
					if (paths.Peek ().dest.x < transform.position.x) {
						np.x -= speed;
						if (np.x < paths.Peek ().dest.x)
							np.x = paths.Peek ().dest.x;
					}
					if (paths.Peek ().dest.x > transform.position.x) {
						np.x += speed;
						if (np.x > paths.Peek ().dest.x)
							np.x = paths.Peek ().dest.x;
					}
					if (paths.Peek ().dest.y < transform.position.y) {
						np.y -= speed;
						if (np.y < paths.Peek ().dest.y)
							np.y = paths.Peek ().dest.y;
										}
					if (paths.Peek ().dest.y > transform.position.y) {
						np.y += speed;
						if (np.y > paths.Peek ().dest.y)
							np.y = paths.Peek ().dest.y;
					}
					np = RoundCoordinate (np);
					transform.position = np;
				} else {
					Debug.Log ("Move ended");
					// Sinon on dépile et on arrete eventuellement l'animation
					if (paths.Count == 1) {
						string a = BuildAnimName ("Idle", paths.Peek ().o);
						anims.Play (a);
						Debug.Log ("Reset anim");
					}
						
					paths.Dequeue ();

				}
			} else {
				// On arrete
			}


		}

		public void RunTo(int x, int y, Orientation o)
		{
			// Start animation run
			running = true;
			MoveTo (x, y, o);
		}

		public void WalkTo(int x, int y,Orientation o)
		{
			running = false;

			MoveTo (x, y, o);
		}

		private void MoveTo(int x, int y, Orientation o)
		{
			Checkpoint c = new Checkpoint ();
			c.dest = new Vector3();
			c.dest.x = x;
			c.dest.y = y;
			c.dest.z = transform.position.z;
			c.o = o;

			paths.Enqueue (c);
		}

		public void TeleportTo(int x, int y)
		{
			Vector3 p = new Vector3 (x, y, transform.position.z);
			transform.position = p;
		}

		private string BuildAnimName(string anim, Orientation o)
		{
			// Start animation walk
			string animName = this.name+" "+anim+" ";
			switch (o) {
			case Orientation.UP:
				animName += "U";  
				break;
			case Orientation.LEFT:
				animName += "L";  
				break;
			case Orientation.RIGTH:
				animName += "R";  
				break;
			case Orientation.DOWN:
			default:
				animName += "D";  
				break;
			}
			return animName;
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

}