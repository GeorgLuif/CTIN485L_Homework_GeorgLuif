using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Interact();
		}
	}

	public virtual void Interact() {

	}
}
