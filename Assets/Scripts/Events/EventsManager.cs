using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class EventsManager : MonoBehaviour
{
	#region PROPERTIES
	public static EventsManager Instance { get; private set; }
	#endregion


	#region PUBLIC PROPERTIES
	public Transform activeEventsParent;
	#endregion


	#region PRIVATE VARIABLES
	private Event[] mAvailableWorldEvents;

	private List<Event> mActiveEvents;
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;

			mActiveEvents = new List<Event> ();
			mAvailableWorldEvents = Resources.LoadAll<Event> ("Events/");
		}
		else
		{
			Debug.LogError("There is more than one EventsManager in the scene!");
		}
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.C))
		{
			Event randomEvent = InstantiateRandomEvent();

			if (randomEvent)
			{ Debug.LogFormat ("{0} - {1}", randomEvent.displayName, randomEvent.description); }
		}
	}
	#endregion


	#region PUBLIC API
	private Event InstantiateRandomEvent()
	{
		if (mAvailableWorldEvents.Length > 0)
		{
			Event go = Instantiate (mAvailableWorldEvents[Random.Range (0, mAvailableWorldEvents.Length)]);

			go.transform.SetParent (activeEventsParent);

			mActiveEvents.Add (go);

			return go;
		}

		return null;
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}