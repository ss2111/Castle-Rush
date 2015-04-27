using UnityEngine;
using System.Collections;

public class AudioPlaying : MonoBehaviour {
	public AudioClip GameOver;
	AudioSource audioPlayer;
	// Use this for initialization
	void Start () {
		audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioPlayer.isPlaying) {
			audioPlayer.clip = GameOver;
			audioPlayer.Play();
		}
	}
}
