using UnityEngine;
using System.Collections;
namespace Car {
[RequireComponent(typeof(CarMotor))]
[RequireComponent(typeof(CarInteraction))]
	public class CarEffects : MonoBehaviour
	{
		public GameObject smoke;
		private bool running = false;
		
		void Start() {
			smoke.SetActive(false);
		}

		void SetRunning() {
			smoke.SetActive(running);
		}

		public bool Running
		{
			get
			{
				return running;
			}

			set
			{
				running = value;
				SetRunning();
			}
		}

	}
}

