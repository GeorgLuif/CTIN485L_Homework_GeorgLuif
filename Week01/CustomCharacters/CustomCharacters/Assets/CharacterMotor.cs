using UnityEngine;
using System.Collections;
namespace Character
{
	[RequireComponent(typeof(Collider))]

	public class CharacterMotor : Movement.Motor
	{
		private CharacterController controller;
		private Rigidbody rigidB;

		public delegate void MoveAction();
		public static event MoveAction OnJump;
		public static event MoveAction OnLand;


		void Start()
		{
			rigidB = GetComponent<Rigidbody>();
		}

		protected override void Update()
		{
			base.Update();
			velocity = rigidB.velocity;

			//CHANGE IN GROUNDED STATUS
			if (grounded != previouslyGrounded)
			{
			
				previouslyGrounded = grounded;
				// IF WAS UNGROUNDED BUT LANDS
				if(grounded && OnLand != null)
					OnLand();
			}

		}

		public void JumpEvent() {
			print("Jump caused by animation event");
			rigidB.AddForce(transform.TransformDirection(Vector3.up* jumpPower), ForceMode.Acceleration);
		}
		
		protected override void HandleMovement()
		{

			Vector3 movement = new Vector3(0, 0, input.z * speed);

			if (input.y > 0 && OnJump != null)
				OnJump();

			rigidB.AddForce(transform.TransformDirection(movement),ForceMode.Acceleration);
			
			transform.Rotate(rotation);
		}


		public CharacterController Controller
		{
			get
			{
				return controller;
			}

			set
			{
				controller = value;
			}
		}

	}
}