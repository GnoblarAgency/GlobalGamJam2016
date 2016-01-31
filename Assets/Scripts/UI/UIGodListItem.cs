using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGodListItem : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public Image godIcon;
	public Scrollbar favourBar;
	#endregion


	#region UNITY EVENTS
	#endregion


	#region PUBLIC API
	public void SetDetails(Sprite image, float favour)
	{
		godIcon.sprite = image;
		favourBar.value = favour;
	}
	#endregion
}
