using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMotor : MonoBehaviour {

    public float speed = 8f;

	Vector3 movement;
    CharacterController c;

    void Start()
    {
        c = GetComponent<CharacterController>();
    }

	void Update () {

		movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        c.Move(movement * Time.deltaTime * speed);
        
	}
}
