using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour
{

	protected GameObject playerObject;
	public delegate void CollectAction(Collectable c);
	public static event CollectAction OnCollect;

	void Start() {
		playerObject = GameMaster.instance.Character;
	}

	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject == playerObject) {
			Interact();
		}
	}

	void Interact() {
		

		if(OnCollect != null)
			OnCollect(this);
	}
}
