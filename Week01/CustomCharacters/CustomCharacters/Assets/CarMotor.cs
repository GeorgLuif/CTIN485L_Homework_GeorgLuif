using UnityEngine;
using System.Collections;
namespace Car {
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
	public class CarMotor : Movement.Motor
	{
		private Rigidbody rigidBody;

		void Start()
		{
			rigidBody = GetComponent<Rigidbody>();
		}

		protected override void Update()
		{
			base.Update();
			velocity = rigidBody.velocity;
		}

		protected override void HandleMovement()
		{
			rigidBody.AddRelativeForce(input*(speed / 100), ForceMode.VelocityChange);
			print("Adding force to car " + input);
			//controller.Move(transform.TransformDirection(input * (speed / 100)));
			transform.Rotate(rotation * rotSpeed);

		}


	}

}

