using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : tk2dUIBaseDemoController {
	// Attribute to easily get items //

	//Windows
	//public GameObject mainWindow;

	public GameObject textBox;
	public tk2dTextMesh textContainer;
	public tk2dTextMesh speakerTextContainer;

	////////////////////////////////////////////
	private List<string> speakers;
	private List<string> texts;
	private int currentText;
	private bool finished;

	private int charPerLine = 255;

	public DialogManager()
	{
		Reset ();
	}

	public void OnEnable()
	{
		// Affichage + bind event
		currentText = 0;
		if (texts.Count > 0) {
			textContainer.text = texts [0].Substring (0, (texts [0].Length < charPerLine ? texts [0].Length : charPerLine));
			speakerTextContainer.text = speakers [0];
		}
	}

	public void OnMouseDown()
	{
		Debug.Log ("Heeey");
		currentText++;
		if (currentText == texts.Count) {
			finished = true;
		} else {
			textContainer.text = texts [currentText];
			speakerTextContainer.text = speakers [currentText];
		}
	}

	public void OnDisable()
	{
		texts.Clear ();
	}

	public void AddDialog (string _text, string _speaker, string _face)
	{
		speakers.Add( _speaker);
		// Formatage du text
		_text = _text.Trim().Replace("\n", "");
		Debug.Log (_text);
		int offset = 0;
		/*while (_text.Length > 2 * (charPerLine+1)) {
			speakers.Add( _speaker);
			texts.Add(_text.Substring (offset, 2*(charPerLine+1)));
			offset += 2 *( charPerLine+1);
			_text = _text.Substring (charPerLine);
		}*/

		texts.Add(_text);
	}

	private void HandleNext(tk2dUIItem btn)
	{

	}

	public bool IsFinished()
	{
		return finished;
	}

	public void Reset()
	{
		texts = new List<string> ();
		speakers = new List<string> ();
		finished = false;
	}

	// Update is called once per frame
	public void Update () {

	}
}