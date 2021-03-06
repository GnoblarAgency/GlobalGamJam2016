﻿using UnityEngine;
using System.Collections.Generic;

public abstract class Building : MonoBehaviour
{
	#region PROPERTIES
	public bool IsClickable { get; private set; }

	public string DisplayName { get; private set; }

	public float CostToBuild {get ; protected set; }

	public bool NotPurchasable;
	#endregion


	#region PROTECTED VARIABLES
	protected List<ResourceGrowthModifier> mResourceModifiers = new List<ResourceGrowthModifier> ();
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{

	}

	void OnDisable ()
	{
		//clean up any applied modifiers
		if (mResourceModifiers != null)
		{
			foreach(ResourceGrowthModifier rm in mResourceModifiers)
			{
				ResourcesManager.instance.RemoveModifier (rm);
			}
			mResourceModifiers.Clear ();
		}
	}
	#endregion


	#region PUBLIC API
	public override string ToString ()
	{
		return string.Format ("{0}", DisplayName);
	}

	public virtual void OpenUI() {}
	#endregion


	#region HELPER FUNCTIONS
	protected void Init (string displayName, bool isClickable = true)
	{
		IsClickable = isClickable;
		DisplayName = displayName;
	}
	#endregion
}
