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

	public ResourceModifier[] resourceModifiers = new ResourceModifier[0];
	#endregion


	#region PRIVATE VARIABLES
	protected float mEventTimer;

	protected float mEventLength;
	#endregion


	#region UNITY EVENTS
	void OnEnable ()
	{
	}

	void Update ()
	{
		if (isActive)
		{
			mEventTimer += Time.deltaTime;

			if (mEventTimer >= mEventLength)
			{
				mEventTimer = 0f;

				isActive = false;
			}
		}
	}
	#endregion


	#region PUBLIC API
	public void ApplyEffect ()
	{
		throw new System.NotImplementedException ();
	}

	public void RemoveEffect ()
	{
		throw new System.NotImplementedException ();
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}
