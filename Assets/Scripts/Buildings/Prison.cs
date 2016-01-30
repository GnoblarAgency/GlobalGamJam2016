using UnityEngine;

public class Prison : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Prison");
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowPrisonScreen();
	}
	#endregion
}
