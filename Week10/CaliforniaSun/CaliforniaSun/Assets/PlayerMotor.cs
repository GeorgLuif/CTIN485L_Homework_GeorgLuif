using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class PlayerMotor : MonoBehaviour {

    public float speed = 8f;

	Vector3 movement;
    CharacterController c;

	bool disabled = false;

    void Start()
    {
        c = GetComponent<CharacterController>();
    }

	float jumpPower = 0f;

	void Update () {

		if(disabled)
			return;
		

		movement = new Vector3(Input.GetAxis("Horizontal"), Physics.gravity.y + jumpPower, Input.GetAxis("Vertical"));
		
		if(c.isGrounded && Input.GetButtonDown("Jump"))
			jumpPower = Physics.gravity.y * -1.5f;

		if (jumpPower > 0f)
			jumpPower = Mathf.MoveTowards(jumpPower, 0f, Time.deltaTime * -Physics.gravity.y * 1.6f);

        c.Move(transform.TransformDirection(movement) * Time.deltaTime * speed);
        
	}

	public void Disable() {
	if(!disabled)
		StartCoroutine(DisableCoroutine());
	}

	private IEnumerator DisableCoroutine()
	{
		disabled = true;
		yield return new WaitForSeconds(2f);
		disabled = false;
	}
}
