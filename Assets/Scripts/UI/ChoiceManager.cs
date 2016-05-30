using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceManager : tk2dUIBaseDemoController {
	// Attribute to easily get items //

	//Windows
	//public GameObject mainWindow;

	public tk2dUIItem choix1;
	public tk2dUIItem choix2;


	////////////////////////////////////////////
	private int selected;

	private int charPerLine = 255;

	public ChoiceManager()
	{
		selected = -1;
	}

	public void OnEnable()
	{
		selected = -1;

		choix1.OnClickUIItem += HandleClick;
		choix2.OnClickUIItem += HandleClick;
	}

	public void OnMouseDown()
	{

	}

	public void OnDisable()
	{
		choix1.OnClickUIItem -= HandleClick;
		choix2.OnClickUIItem -= HandleClick;
	}

	public void SetChoices (string c1, string c2)
	{
		choix1.GetComponentInChildren<tk2dTextMesh> (true).text = c1;
		choix2.GetComponentInChildren<tk2dTextMesh> (true).text = c2;
	}

	public int GetChoice()
	{
		return selected;
	}

	private void HandleClick(tk2dUIItem btn)
	{
		if (btn == choix1) {
			selected = 0;
		} else {
			selected = 1;
		}
	}


	// Update is called once per frame
	public void Update () {

	}
}