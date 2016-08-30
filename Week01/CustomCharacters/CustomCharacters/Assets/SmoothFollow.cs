using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public Transform target;
	public float distance = 10.0f;
	public float height = 5.0f;
	Vector3 offset;

	void Start() {
		offset = target.position - transform.position;
	}

	void LateUpdate()
	{
		if (!target) return;

		float currentHeight = transform.position.y;


		transform.position = target.position - offset;

		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
		
		//transform.LookAt(target);
	}
}