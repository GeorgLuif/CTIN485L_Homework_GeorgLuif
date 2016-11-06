using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {



	Vector3 movement;

	void Update () {
		movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		transform.Translate(movement * Time.deltaTime * 8f);
	}
}
