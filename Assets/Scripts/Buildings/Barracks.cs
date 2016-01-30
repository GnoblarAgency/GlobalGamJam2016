using UnityEngine;

public class Barracks : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Barracks");
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowBarracksScreen();
	}
	#endregion
}
