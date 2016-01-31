using UnityEngine;

public class House : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("House", false);
		CostToBuild = 300f;
	}

	void OnEnable ()
	{
		ResourceGrowthModifier modifier = new ResourceGrowthModifier ( ResourceType.Population , 2.5f);
		ResourcesManager.instance.ApplyModifier (modifier);
		mResourceModifiers.Add (modifier);
	}
	#endregion
}
