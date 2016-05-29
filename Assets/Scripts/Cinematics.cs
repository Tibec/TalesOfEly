using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

public class Cinematics 
{
	private tk2dCamera camera;


	public void Init(tk2dCamera _camera)
	{
		camera = _camera;
	}

	public void Play(String map, int id)
	{
		Type item = this.GetType ();
		MethodInfo function = item.GetMethod("play_"+map+"_"+id);
		function.Invoke (this, null);
	}
	private void play_village_1()
	{
		/*
		 	Camera.SetPosition(x, y)
			FadeCamera();
			LoadCharacter(xx, posX, posY);
			MoveCharacter(xx, A, B);
			AttachCameraToCharacter(x);
			
		*/
	}
}