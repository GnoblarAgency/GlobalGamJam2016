using UnityEngine;

public class Farm : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Farm", true);
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowFarmScreen();
	}
	#endregion
}
