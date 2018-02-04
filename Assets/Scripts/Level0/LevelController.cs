using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	AudioSource levelMusic;

	private UnityAction playerDeadListener;

	// Use this for initialization
	void Start () {
		levelMusic = GetComponent<AudioSource> ();
		playerDeadListener = new UnityAction (onPlayerDie);
		EventManager.StartListening ("die", playerDeadListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onPlayerDie() {
		// Disable level music
		levelMusic.Stop();
		StartCoroutine (LevelReloader());

	}

	IEnumerator LevelReloader()
	{
		// Reload a level after a few seconds
		yield return new WaitForSeconds(7.0f);
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
		
}
