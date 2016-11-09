using UnityEngine;
using System.Collections;

public class PlayAudioOnStart : MonoBehaviour {

	void Start () {
		GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
		GetComponent<AudioSource>().Play();
	}
	
}
