using UnityEngine;
using System.Collections;

public abstract class Event : MonoBehaviour
{
	#region PROPERTIES
	#endregion

	#region PUBLIC VARIABLES
	public string displayName;

	public Sprite image;

	[TextArea(3, 10)]
	public string description;
	public float eventLength;

	public ResourceGrowthModifier[] resourceModifiers = new ResourceGrowthModifier[0];
	#endregion


	#region PRIVATE VARIABLES
	protected float mEventTimer;
	#endregion


	#region UNITY EVENTS
	void Update ()
	{
		mEventTimer += Time.deltaTime;

		if (mEventTimer >= eventLength)
		{
			mEventTimer = 0f;

			RemoveEffect();
		}
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

		EventsManager.Instance.RemoveEvent (this);
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}
