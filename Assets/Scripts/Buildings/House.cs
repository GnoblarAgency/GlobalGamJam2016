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
		ResourceModifier modifier = new ResourceModifier ( ResourceType.Population , 1f);
		ResourcesManager.instance.ApplyModifier (modifier);
		mResourceModifiers.Add (modifier);
	}
	#endregion
}
