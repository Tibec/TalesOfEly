using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Entities;

public class StoryManager {

	List<Character> chars;
	List<Scene> scenes;

	TextAsset xdoc;

	private StoryManager()
	{
		Init ();
	}

	public Scene GetScene(int id) {
		foreach (Scene s in scenes) {
			if (s.Id == id) {
				Debug.Log (s.Map);
				return s;
			}
		}
		throw new Exception ("Cannot found scene id :" + id);
	}
	public Character GetCharacter(int id) {
		foreach (Character s in chars) {
			if (s.Id == id)
				return s;
		}
		throw new Exception ("Cannot found char id :" + id);
	}

    public Character GetCharacter(string name)
    {
        foreach (Character s in chars)
        {
            if (s.Name == name)
                return s;
        }
        throw new Exception("Cannot found char name :" + name);
    }

    private void Init()
    {
		xdoc = Resources.Load("story") as TextAsset;
		XDocument xdocD = XDocument.Parse(xdoc.text);
		ParseCharacters(xdocD);
		ParseScenes (xdocD);
	}

	private void ParseCharacters(XDocument doc)
	{
		IEnumerable<XElement> char_tag =
			(from el in doc.Root.Elements("characters")
				//where (string)el.Attribute("id") == id.ToString()
				select el);

		List<Character> l = new List<Character>();
		XElement c = char_tag.First();

		IEnumerable<XElement> chars =
			(from el in c.Elements("char")
				//where (string)el.Attribute("id") == id.ToString()
				select el);

		foreach (XElement ch in chars)
		{
			Debug.Log("Found character : "+ (ch.FirstNode as XText).Value);
			Character cha = new Character((int)ch.Attribute("id"), (string)ch.Attribute("face"), (ch.FirstNode as XText).Value);
			l.Add(cha);
			//Console.WriteLine (ch);

		}
		this.chars = l;
	}

	private void ParseScenes(XDocument doc)
	{
		IEnumerable<XElement> _tag =
			(from el in doc.Root.Elements("scenes")
				//where (string)el.Attribute("id") == id.ToString()
				select el);

		List<Scene> l = new List<Scene>();
		XElement c = _tag.First();

		IEnumerable<XElement> scenes =
			(from el in c.Elements("scene")
				//where (string)el.Attribute("id") == id.ToString()
				select el);

		foreach (XElement s in scenes)
		{
			List<Content> lc = new List<Content>();
			IEnumerable<XElement> content_tag =
				(from el in s.Elements("content")
					//where (string)el.Attribute("id") == id.ToString()
					select el);
			XElement ct = content_tag.First();

			IEnumerable<XElement> cins =
				(from el in ct.Elements("cinematic")
					//where (string)el.Attribute("id") == id.ToString()
					select el);
			foreach (XElement cin in cins)
			{
				Content cont = Content.buildCinematic((int)cin.Attribute("id"));
				lc.Add(cont);
				//Console.WriteLine (lc.Count ());
			}

			IEnumerable<XElement> dialogs =
				(from el in ct.Elements("dialog")
					//where (string)el.Attribute("id") == id.ToString()
					select el);
			foreach (XElement d in dialogs)
			{
				IEnumerable<XElement> parts =
					(from el in d.Elements("part")
						//where (string)el.Attribute("id") == id.ToString()
						select el);

				List<Part> l_parts = new List<Part>();
				foreach (XElement p in parts)
				{
					//Console.WriteLine ("---------------------------Parsing part-----------------------");
					Part part = new Part((int)p.Attribute("char"), (p.FirstNode as XText).Value);
					l_parts.Add(part);
				}
				//Console.WriteLine ("---------------------------Parsing Dialog------------------------------");
				//---------------------------Parsing Dialogs------------------------------
				Content diag = Content.buildDialog(l_parts);
				lc.Add(diag);
				//Console.WriteLine (lc.Count ());
			}

			Scene sc = new Scene((int)s.Attribute("id"), (string)s.Attribute("map"), lc);
			IEnumerable<XElement> choices =
				(from el in s.Elements("choices")
					//where (string)el.Attribute("id") == id.ToString()
					select el);
			foreach (XElement cho in choices)
			{
				IEnumerable<XElement> choices_s =
					(from el in cho.Elements("c")
						//where (string)el.Attribute("id") == id.ToString()
						select el);

				List<Choice> l_choices = new List<Choice>();
				foreach (XElement p in choices_s)
				{
					//Console.WriteLine ("---------------------------Parsing part-----------------------");
					Choice choi = new Choice((int)p.Attribute("goto"), (p.FirstNode as XText).Value);
					l_choices.Add(choi);
				}
				//Console.WriteLine ("---------------------------Parsing Dialog------------------------------");
				//---------------------------Parsing Dialogs------------------------------
				sc.addChoices(l_choices);
				//Console.WriteLine (lc.Count ());
			}
			l.Add(sc);
			//Console.WriteLine (ch);
		}
		this.scenes = l;
	}

	//-----------------------------------------------------------------

	// Singletonisation //
	private static StoryManager instance;
	public static StoryManager Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new StoryManager();
			}
			return instance;
		}
	}
	//-------------------//

}