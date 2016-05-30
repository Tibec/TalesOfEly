using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Entities 
{

	public class Scene : System.Attribute{

		private int id;
		private string map;
		private List<Content> contents;
		private List<Choice> choices;

	

		public List<Choice> Choices {
			get { return choices; }
		}


		public Scene(int i, string m, List<Content> c){
			id = i;
			map = m;
			contents = c;
		}

		public void addChoices(List<Choice> ch){
			this.choices = ch;
		}
			
		public List<Content> Content {
			get { return contents; }
		}
			
		public int Id {	
			get { return id; }
		}

		public string Map {
			get { return map; }
		}

	}


	public class Part : System.Attribute
	{
		private int chr_id;
		private string text;


		public Part(int c, string t){
			chr_id = c;
			text = t;
		}

		public int Char {
			get { return chr_id; }
		}

		public string Text {
			get { return text; }
		}
	}

	public class Choice : System.Attribute
	{
		private int next_scene;
		private string text;


		public Choice(int ns, string t){
			next_scene = ns;
			text = t;
		}

		public int get_next_scene(){
			return next_scene;
		}

		public string get_text(){
			return text;
		}

		public override string ToString(){

			return get_text ();
		}


	}
	public enum content_type {DIALOG, CINEMATIC, CHOICE};

	public class Content : System.Attribute
	{
		private int id;
		public content_type type;

		private List<Part> dialogParts;

		public static Content buildDialog(List<Part> p){
			Content d = new Content (content_type.DIALOG, 0);
			d.dialogParts = p;
			return d;
		}
		public static Content buildCinematic(int i){
			Content c = new Content (content_type.CINEMATIC, i);
			return c;
		}

		public Content (content_type t, int i){
			id = i;
			type = t;
		}
		public Content (content_type t){
			type = t;
		}

		public List<Part> Parts {
			get { return dialogParts; }
		}

		public int get_id(){
			return id;
		}
		public content_type get_type(){
			return type;
		}
	}

}