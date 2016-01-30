using UnityEngine;
using System.Collections;

public abstract class Event : MonoBehaviour
{
	#region PROPERTIES
	public bool isActive { get; private set; }
	#endregion

	#region PUBLIC VARIABLES
	public string displayName;

	[TextArea(3, 10)]
	public string description;
	public float eventLength;

	public ResourceModifier[] resourceModifiers = new ResourceModifier[0];
	#endregion


	#region PRIVATE VARIABLES
	protected float mEventTimer;
	#endregion


	#region UNITY EVENTS
	void OnEnable ()
	{
		isActive = true;
	}

	void Update ()
	{
		if (isActive)
		{
			mEventTimer += Time.deltaTime;

			if (mEventTimer >= eventLength)
			{
				mEventTimer = 0f;

				isActive = false;

				RemoveEffect();
			}
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
