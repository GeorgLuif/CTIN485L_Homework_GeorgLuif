using UnityEngine;
using System.Collections;
using Car;
public class CarInteraction : Interactable {

	private bool inUse = false;
	private CarEffects carEffects;


	void Start(){
		carEffects = GetComponent<CarEffects>();
	}
	public override void Interact()
	{
		inUse = !inUse;
		if(inUse) {
			GameMaster.instance.VehicleState = VehicleState.Car;
		}
		
		else {
			GameMaster.instance.VehicleState = VehicleState.None;
			GameMaster.instance.CharacterMotor.transform.position = transform.position + Vector3.right * 2f;
		}

		if (carEffects != null)
			carEffects.Running = inUse;

	}


}
