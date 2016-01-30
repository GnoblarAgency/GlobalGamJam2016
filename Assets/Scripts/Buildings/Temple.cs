using UnityEngine;

public class Temple : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Temple");
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowTempleScreen();
	}
	#endregion
}
