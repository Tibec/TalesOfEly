using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

public class TextBox : MonoBehaviour
{


    public Text dialog;
    public TextAsset xml;
    public TextAsset xmlDiag;
    public TextAsset xmlChar;
    public TextAsset xmlScen;

    // Use this for initialization
    void Start()
    {
        dialog = GetComponent<Text>();
        XDocument xdocD = XDocument.Parse(xmlDiag.text);
        XDocument xdocC = XDocument.Parse(xmlChar.text);
        Character.set_xdoc(xdocC);
        Dialogs.set_xdoc(xdocD);
        
        
        dialog.text = Dialogs.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //dialog = GetComponent<Text>();
    }
}

class CustomException : Exception
{
	public CustomException(string message)
	{

	}
}

[System.AttributeUsage(System.AttributeTargets.Class |
	System.AttributeTargets.Struct,
	AllowMultiple = true)]// multiuse attribute


public class Character : System.Attribute
{
	//-------------------------------Private--------------------------------
	private static List<Character> all = new List<Character>();
    private static XElement root;
	private string id;
	private string name;
    public static void set_xdoc(XDocument xchar)
    {
            //Console.WriteLine("Real Load from XML File");
        root = xchar.Root;
        loadCharacters();
    }

    private static void loadCharacters()
	{
        if (root == null)
            throw new CustomException("Make sure you set the XML doc from which the characters are loaded!");
        //return "FUCK";
        else
        {
            IEnumerable<XElement> chars =
                (from el in root.Elements("char")
                     //where (string)el.Attribute("id") == id.ToString()
                 select el);

            List<Character> l = new List<Character>();
            foreach (XElement c in chars)
            {
                Character ch = new Character((string)c.Attribute("id"), (c.FirstNode as XText).Value);
                l.Add(ch);
            }
            all = l;
            //return "YEAH";
        }
	}

	//-------------------------------Public Methods--------------------------------
	public static List<Character> get_all(){
        loadCharacters();
        return all;
	}

	private Character (string i, string n){
		id = i;
		name = n;
	}
	public static Character find(int i)
	{
		//Input Control to be done 
		loadCharacters ();
		foreach (Character c in all){
			if (c.get_id () == i.ToString())
				return c;
		}
		throw new CustomException("Character Not Found");
	}

	public static Character find(string i)
	{
		//Input Control to be done 
		loadCharacters ();
		foreach (Character c in all){
			if (c.get_id () == i)
				return c;
		}
		throw new CustomException("Character Not Found");
	}

	public string get_name(){
		return name;
	}
	public string get_id(){
		return id.ToString();
	}

}

public class Dialog : System.Attribute
{
	private string id;

	private List<Part> parts;

	public Dialog(string i, List<Part> p){
		id = i;
		parts = p;
	}
	public string ToString(){
		string render = "";
		foreach (Part p in parts) {

			render = render + p.ToString();
			render = render + Environment.NewLine;
		}
		return render;
	}

	public string get_id(){
		return id;
	}
}

public class Part : System.Attribute
{
	private Character chr;
	private string text;

	public Part(Character c, string t){
		chr = c;
		text = t;
	}

	public string get_chr(){
		return chr.get_name();
	}

	public string get_text(){
		return text;
	}

	public override string ToString(){
		string render = get_chr () + ":" + get_text ();
		return render;
	}


}

public class Dialogs : System.Attribute
{
	private static List<Dialog> all = new List<Dialog>();
    private static XElement root;

	private Dialogs (){
	}

	private static void loadDialogs()
	{
        if (root == null)
            //return "FUCK";
            throw new CustomException("Make sure you set the XML doc from which the dialogs are loaded!");
        else
        {
            IEnumerable<XElement> dialogs =
                (from el in root.Elements("d")
                 select el);

            List<Dialog> l = new List<Dialog>();

            foreach (XElement d in dialogs)
            {
                //Console.WriteLine ("---------------------------Getting Dialogs' parts-----------------------");
                IEnumerable<XElement> parts =
                    (from el in d.Elements("part")

                     select el);

                List<Part> l_parts = new List<Part>();
                foreach (XElement p in parts)
                {
                    //Console.WriteLine ("---------------------------Parsing part-----------------------");
                    Part part = new Part(Character.find((string)p.Attribute("char")), (p.FirstNode as XText).Value);
                    l_parts.Add(part);
                }
                //Console.WriteLine ("---------------------------Parsing Dialog------------------------------");
                Dialog diag = new Dialog((string)d.Attribute("id"), l_parts);
                l.Add(diag);
            }
            all = l;
            //return "YEAH";
        }
	}
    /*public static List<Dialog> get_all(){
			loadDialogs ();
			return all;
		}*/


    public static void set_xdoc(XDocument xchar)
    {

            //Console.WriteLine("Real Load from XML File");
            root = xchar.Root;

    }

    public static string ToString(){
		 loadDialogs ();
        if (all.Count() == 0)
            throw new CustomException("No dialogs found!");
        int i = 1;
		string render = "----------------------Dialogs-----------------------------\n";
		string end = "----------------------Dialogs: End-----------------------------\n";
		foreach (Dialog d in all) {
			string sd = "----------------------Dialog " + i.ToString() + ": Start-----------------------------\n";
			render = render + sd;
			render = render + d.ToString(); 
			//foreach (XElement e in el.Elements())
			string ed = "----------------------Dialog " + i.ToString() + ": End-----------------------------\n";
			render = render + ed;
			i = i + 1;
		}
		render = render + end;
		return render;
	}

	public Dialog find(int id){
		loadDialogs ();
		foreach (Dialog d in all)
			if (d.get_id () == id.ToString ())
				return d;
		throw new CustomException ("Dialog Not Found");
	}
	public Dialog find(string id){
		loadDialogs ();
		foreach (Dialog d in all)
			if (d.get_id () == id)
				return d;
		throw new CustomException ("Dialog Not Found");
	}

    public static int count()
    {
        return all.Count();
    }
}



