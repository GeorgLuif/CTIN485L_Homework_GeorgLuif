using UnityEngine;
using System.Collections;


namespace Character {
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CharacterMotor))]
	public class CharacterAnimations : MonoBehaviour
	{

		private Animator anim;
		private CharacterMotor c;

		void Start()
		{
			anim = GetComponent<Animator>();
			c = GetComponent<CharacterMotor>();
		}

		void OnEnable() {
			CharacterMotor.OnJump += Jump;
		}
		void OnDisable() {
			CharacterMotor.OnJump -= Jump;
		}

		void Update()
		{
			anim.SetFloat("velocity", c.input.z);
			anim.SetBool("grounded", c.grounded);
		}

		void Jump() {
			anim.SetTrigger("jump");
		}

	}
}

