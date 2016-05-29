using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using loadDialogs;

public class TextBox : MonoBehaviour {

	tk2dTextMesh textMesh;
    TextAsset xdoc;

	int score = 0;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<tk2dTextMesh>();
        xdoc = Resources.Load("story") as TextAsset;
        XDocument xdocD = XDocument.Parse(xdoc.text);
        Character.set_xdoc(xdocD);
        Scene.set_xdoc(xdocD);
        
        textMesh.text = Scene.count().ToString();
	}


    void init()
    {

    }

	// Update is called once per frame
	void Update () {
			//textMesh.text = "SCORE: 2";

			// This is important, your changes will not be updated until you call Commit()
			// This is so you can change multiple parameters without reconstructing
			// the mesh repeatedly
			//textMesh.Commit();
	}
}