using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

	public Animator a;


	public void ShootAnimation() {
		a.SetTrigger("Shoot");
	}
	public void JumpAnimation() {
		a.SetTrigger("Jump");
	}
	public void DeathAnimation() {
		a.SetTrigger("Die");
		Debug.Log("Playing death animation");
	}
}
