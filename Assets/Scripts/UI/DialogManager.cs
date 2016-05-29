using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : tk2dUIBaseDemoController {
	// Attribute to easily get items //

	//Windows
	//public GameObject mainWindow;

	public GameObject textBox;
	public tk2dTextMesh textContainer;

	////////////////////////////////////////////
	private List<string> speakers;
	private List<string> texts;
	private int currentText;
	private bool finished;

	public DialogManager()
	{
		texts = new List<string> ();
		speakers = new List<string> ();
		finished = false;
	}

	public void OnEnable()
	{
		Debug.Log (texts.Count);
		// Affichage + bind event
		currentText = 0;
		textContainer.text = texts[0].Substring (0, (texts[0].Length < 42 ? texts[0].Length : 42));
	}

	public void OnMouseDown()
	{
		Debug.Log ("Heeey");
		currentText++;
		if (currentText == texts.Count) {
			finished = true;
		} else {
			textContainer.text = texts [currentText];
		}
	}

	public void OnDisable()
	{
		texts.Clear ();
	}

	public void AddDialog (string _text, string _speaker, string _face)
	{
		Debug.Log ("Coc");
		speakers.Add( _speaker);

		// Formatage du text
		string format = "";
		string remain = _text;
		while (remain.Length > 42) {
			format += remain.Substring (0, 42);
			format += "\n";
			remain = remain.Substring (42);
		}
		format += remain;
		Debug.Log (format);
		_text = format;
		while (_text.Length > 2 * 42) {
			speakers.Add( _speaker);
			texts.Add(_text.Substring (0, 84));
			_text = _text.Substring (84);
		}

		texts.Add(_text);

	}

	private void HandleNext(tk2dUIItem btn)
	{

	}

	public bool IsFinished()
	{
		return finished;
	}

	// Update is called once per frame
	public void Update () {

	}
}