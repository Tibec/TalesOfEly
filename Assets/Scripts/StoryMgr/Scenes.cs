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

	public enum content_type {DIALOG, CINEMATIC, CHOICE};

	public class Part : System.Attribute
	{
		private int chr_id;
		private string text;


		public Part(int c, string t){
			chr_id = c;
			text = t;
		}

		public int get_chr(){
			return chr_id;
		}

		public string get_text(){
			return text;
		}

		public override string ToString(){
			string render = get_chr () + ":" + get_text ();
			return render;
		}


	}

	public class Choice : System.Attribute
	{
		private string next_scene;
		private string text;


		public Choice(string ns, string t){
			next_scene = ns;
			text = t;
		}

		public string get_next_scene(){
			return next_scene;
		}

		public string get_text(){
			return text;
		}

		public override string ToString(){

			return get_text ();
		}


	}
	public class Content : System.Attribute
	{
		private string id;
		public static content_type type;

		private List<Part> parts;

		public static Content buildDialog(string i, List<Part> p){
			Content d = new Content (i, content_type.DIALOG);
			d.parts = p;
			return d;
		}
		public static Content buildCinematic(string i){
			Content c = new Content (i, content_type.CINEMATIC);
			return c;
		}

		public Content (string i, content_type t){
			id = i;
			type = t;
		}
		public Content (content_type t){
			type = t;
		}

		public string ToStringDialog(){
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
		public content_type get_type(){
			return type;
		}
	}

}