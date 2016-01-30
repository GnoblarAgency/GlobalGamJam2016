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
			mAvailableWorldEvents = Resources.LoadAll<Event> ("Events/World Events");
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
			Event randomEvent = InstantiateEvent(mAvailableWorldEvents[Random.Range (0, mAvailableWorldEvents.Length)]);

			if (randomEvent)
			{ Debug.LogFormat ("{0} - {1}", randomEvent.displayName, randomEvent.description); }
		}
	}
	#endregion


	#region PUBLIC API
	public Event InstantiateCurse (Curse cursePrefab)
	{
		AudioManager.Instance.PlayCurse ();
		return InstantiateEvent (cursePrefab);
	}

	public Event InstantiateBlessing (Blessing blessingPrefab)
	{
		AudioManager.Instance.PlayBlessing ();
		return InstantiateEvent (blessingPrefab);
	}

	public Event InstantiateEvent(Event eventPrefab)
	{
		Event activeEvent = Instantiate (eventPrefab);

		activeEvent.transform.SetParent (activeEventsParent, false);

		mActiveEvents.Add (activeEvent);
		activeEvent.ApplyEffect ();

		UIManager.instance.ShowEventScreen (activeEvent);

		return activeEvent;
	}

	public void RemoveEvent(Event activeEvent)
	{
		mActiveEvents.Remove (activeEvent);

		Destroy(activeEvent.gameObject);
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}