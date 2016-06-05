using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Entities 
{
	public class Character : System.Attribute
	{
		//-------------------------------Private--------------------------------
		private XElement root;
		private int id;
		private string profile;
		private string name;

	

		//-------------------------------Public Methods--------------------------------

		public Character (int i, string picture,string n){
			id = i;
			profile = picture; 
			name = n;
		}

		public string Name
		{
			get {
				return name;
			}
		}
		public int Id {
			get {
				return id;
			}
		}
		public string Profile {
			get { return profile; }
            set { this.profile = value; }
		}

    }
}