using UnityEngine;
using System.Collections;
namespace Movement
{
	public class Motor : MonoBehaviour
	{

		public float speed = 3.5f;
		public float rotSpeed = 2.5f;
		public float jumpPower = 4f;
		private float jump = 0;
		protected Vector3 velocity;
		public Vector3 input;
		protected Vector3 rotation;
		public float boost;
		protected float gravity = 0f;
		public float maxGroundDistance = 0.1f;
		public bool grounded = false;
		protected bool previouslyGrounded = false;

		protected virtual void Update()
		{
			HandleInput();
			HandleMovement();
			CheckGrounded();
		}


		protected virtual void HandleInput() {
			
			rotation = new Vector3(0, Input.GetAxis("Horizontal")*rotSpeed, 0);
			boost = Input.GetAxis("Sprint");

			jump = 0f;

			if (Input.GetButtonDown("Jump"))
				jump = 1f;

			input = new Vector3(0, jump , Input.GetAxis("Vertical") * (1 + boost));
		}

		protected virtual void HandleMovement() { print("please override me"); }

		protected void CheckGrounded()
		{
			RaycastHit[] hits;

#if UNITY_EDITOR
			Debug.DrawLine(transform.position , transform.position  + (Vector3.down * maxGroundDistance));
#endif
			bool tempGrounded = false;

			hits = Physics.RaycastAll(transform.position, Vector3.down, maxGroundDistance);

			foreach(RaycastHit r in hits) {
				if (r.collider.gameObject != gameObject)
					tempGrounded = true;
			}

			grounded = tempGrounded;

		}

		public Vector3 Velocity
		{
			get
			{
				return velocity;
			}

			set
			{
				Debug.LogWarning("Velocity is readOnly");
			}
		}


	}

}
