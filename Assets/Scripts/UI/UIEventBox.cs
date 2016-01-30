using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEventBox : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public Image eventImage;
	public Text title;
	public Text description;
	#endregion


	#region UNITY EVENTS
	#endregion


	#region PUBLIC API
	public void SetDetails(Sprite image, string titleText, string descriptionText)
	{
		eventImage.sprite = image;
		title.text = titleText;
		//description = descriptionText;
	}
	#endregion
}
