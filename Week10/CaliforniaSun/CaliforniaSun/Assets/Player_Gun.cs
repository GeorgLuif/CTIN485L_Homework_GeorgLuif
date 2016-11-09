using UnityEngine;
using System.Collections;

public class Player_Gun : MonoBehaviour {

	Camera c;
	public AudioSource fireAudio;
	public ParticleSystem fireParticle;
	public float fireCooldown;

	private float fireCooldownTimer = -1f;
	void Start () {
		c = GetComponentInChildren<Camera>();
	}

	void Update () {
		if (fireCooldownTimer > 0)
			fireCooldownTimer -= Time.deltaTime;


		if(Input.GetButtonDown("Fire1") && fireCooldownTimer<0) {
			fireAudio.pitch = Random.Range(0.8f, 1.1f);
			fireAudio.Play();
			fireParticle.Play();
		}
			
		
	}
}
