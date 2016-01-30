using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] Screams;
	public AudioClip[] Blessings;
	public AudioClip[] Curses;
	public AudioSource source;

	static AudioManager Instance;


	public void Start()
	{
		Instance = this;
	}


	public void PlayCurse () 
	{
		source.clip = Curses[(int) Random.Range(0,Curses.Length)];
		source.Play();
	}


	public void PlayScream () 
	{
		source.clip = Screams[(int) Random.Range(0,Screams.Length)];
		source.Play();
	}

	public void PlayBlessing () 
	{
		source.clip = Blessings[(int) Random.Range(0,Blessings.Length)];
		source.Play();
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

}
