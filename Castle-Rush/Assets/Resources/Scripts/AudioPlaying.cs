﻿using UnityEngine;
using System.Collections;

public class AudioPlaying : MonoBehaviour {
	public AudioClip GameOver;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			audio.clip = GameOver;
			audio.Play();
		}
	}
}
