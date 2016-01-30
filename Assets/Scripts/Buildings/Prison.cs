using UnityEngine;

public class Prison : Building
{
	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Prison");
		CostToBuild = 300;
	}

	void OnEnable ()
	{
		ResourceGrowthModifier modifier = new ResourceGrowthModifier ( ResourceType.Prisoners , 1f);
		ResourcesManager.instance.ApplyModifier (modifier);
		mResourceModifiers.Add (modifier);
	}
	#endregion
}
