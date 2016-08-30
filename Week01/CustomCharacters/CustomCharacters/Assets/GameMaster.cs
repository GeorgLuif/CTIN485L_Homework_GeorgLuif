using UnityEngine;
using System.Collections;
using Character;
using Car;
public class GameMaster : MonoBehaviour {

	private VehicleState vehicleState;

	public static GameMaster instance;

	private CharacterMotor characterMotor;
	private CarMotor carMotor;
	private SmoothFollow smoothFollow;
	private GameObject character;


	void Awake()
	{
		instance = this;

		characterMotor = FindObjectOfType<CharacterMotor>();
		carMotor = FindObjectOfType<CarMotor>();
		smoothFollow = FindObjectOfType<SmoothFollow>();
		character = FindObjectOfType<Character.Character>().gameObject;
	}


	IEnumerator Start() {
		
		HandleVehicle();
		yield break;
	}

	void OnEnable() {
		Collectable.OnCollect += Collect;
	}

	void OnDisable() {
		Collectable.OnCollect -= Collect;
	}

	void Collect(Collectable c) {
		print("Collected " + c);

		
	}

	void HandleVehicle()
	{
		if (carMotor == null || characterMotor == null)
			return;
		characterMotor.enabled = false;
		carMotor.enabled = false;
		characterMotor.gameObject.SetActive(false);

		switch (vehicleState)
		{
			case VehicleState.None:
				characterMotor.enabled = true;
				characterMotor.gameObject.SetActive(true);
				smoothFollow.target = characterMotor.transform;
				break;
			case VehicleState.Car:
				carMotor.enabled = true;
				smoothFollow.target = carMotor.transform;
				break;
			default:
				break;
		}
	}


	public VehicleState VehicleState
	{
		get
		{
			return vehicleState;
		}

		set
		{
			vehicleState = value;
			HandleVehicle();
		}
	}

	public CharacterMotor CharacterMotor
	{
		get
		{
			return characterMotor;
		}

		set
		{
			characterMotor = value;
		}
	}

	public GameObject Character
	{
		get
		{
			return character;
		}

		set
		{
			print("Character is readonly");
			//character = value;
		}
	}

	


}

public enum VehicleState { None, Car}
