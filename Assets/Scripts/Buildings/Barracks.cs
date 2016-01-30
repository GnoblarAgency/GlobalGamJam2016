using UnityEngine;
using System.Collections.Generic;

public class Barracks : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Barracks");
		CostToBuild = 500;
	}

	void OnEnable ()
	{
		ResourceGrowthModifier modifier = new ResourceGrowthModifier ( ResourceType.Prisoners , 3f);
		ResourcesManager.instance.ApplyModifier (modifier);
		mResourceModifiers.Add (modifier);
	}
	#endregion


	#region PUBLIC API
	public override void OpenUI() 
	{
		UIManager.instance.ShowBarracksScreen();
	}
	#endregion
}
