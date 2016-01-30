using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	#region PROPERTIES
	public static AudioManager Instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	public AudioClip[] Screams;
	public AudioClip[] Blessings;
	public AudioClip[] Curses;
	public AudioSource source;
	#endregion


	#region UNITY EVENTS
	public void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError ("There is more than one AudioManager in the scene!");
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			PlayScream();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			PlayBlessing();
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			PlayCurse();
		}
	}
	#endregion


	#region PUBLIC API
	public void PlayCurse () 
	{
		source.clip = Curses[(int) Random.Range(0, Curses.Length)];
		source.Play();
	}

	public void PlayScream () 
	{
		source.clip = Screams[(int) Random.Range(0, Screams.Length)];
		source.Play();
	}

	public void PlayBlessing () 
	{
		source.clip = Blessings[(int) Random.Range(0, Blessings.Length)];
		source.Play();
	}
	#endregion
}
