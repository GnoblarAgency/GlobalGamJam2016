using UnityEngine;

public class Farm : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Farm", true);
		CostToBuild = 600;
	}

	void OnEnable ()
	{
		ResourceModifier modifier = new ResourceModifier ( ResourceType.Food , 5f);
		ResourcesManager.instance.ApplyModifier (modifier);
		mResourceModifiers.Add (modifier);
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowFarmScreen();
	}
	#endregion
}
