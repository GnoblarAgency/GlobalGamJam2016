﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class God : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public string displayName;
	public string title;

	[TextArea (3, 10)]
	public string biography;

	public Sprite image;

	public ResourceGrowthModifier[] resourceModifiers = new ResourceGrowthModifier[0]; 

	public Curse[] curses = new Curse[0];
	public Blessing[] blessings = new Blessing[0];

	public FavourResource favour = new FavourResource (9, -1);
	#endregion


	#region UNITY EVENTS
	void Update ()
	{
		
	}
	#endregion


	#region PUBLIC API
	public void ApplyEffect ()
	{
		for (int i = 0; i < resourceModifiers.Length; ++i)
		{ ResourcesManager.instance.ApplyModifier (resourceModifiers[i]); }
	}

	public void RemoveEffect ()
	{
		for (int i = 0; i < resourceModifiers.Length; ++i)
		{ ResourcesManager.instance.RemoveModifier (resourceModifiers[i]); }
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}