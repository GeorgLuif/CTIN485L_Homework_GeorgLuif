using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public Vector3 rotation;
	public Vector3 positionMin;
	public Vector3 positionMax;

	void Update() {

		if (rotation != Vector3.zero)
			transform.Rotate(rotation);
	}


}
