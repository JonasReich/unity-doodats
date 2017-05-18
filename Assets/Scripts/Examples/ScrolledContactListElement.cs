//-------------------------------------------
// Copyright (c) 2017 - JonasReich
//-------------------------------------------

using UnityDoodats.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UnityDoodats.Examples
{
	public class ScrolledContactListElement : ScrolledListElement<Contact>
	{
		public Image pictureImage;
		public Text nameText;
		public Text descriptionText;

		public override void UpdateData(Contact data)
		{
			base.UpdateData(data);

			// Update UI
			pictureImage.sprite = data.picture;
			nameText.text = data.name;
			descriptionText.text = data.description;
		}
	}
}
