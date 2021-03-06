//-------------------------------------------
// Copyright (c) 2017 - JonasReich
//-------------------------------------------

using System;
using UnityEngine;

namespace Doodads.Examples
{
	/// <summary>
	/// An adressbook contact
	/// </summary>
	[Serializable]
	public class Contact
	{
		public Sprite picture;

		public string name;

		[TextArea(5,10)]
		public string description;
	}
}
