using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Gun : NetworkBehaviour
{

	Camera c;

	public GameObject fireParticlePrefab;
	public Transform fireParticleSpawnPos;
	public float fireCooldown;

	private float fireCooldownTimer = -1f;

	private PlayerAnimations pAnim;


	void Start()
	{
		c = GetComponentInChildren<Camera>();
		ClientScene.RegisterPrefab(fireParticlePrefab);
		pAnim = GetComponent<PlayerAnimations>();
	}

	void Update()
	{
		if (fireCooldownTimer > 0)
			fireCooldownTimer -= Time.deltaTime;


		if (Input.GetButtonDown("Fire1") && fireCooldownTimer < 0 && isLocalPlayer)
			CmdFire();

	}

	[Command]
	public void CmdFire()
	{
		RaycastHit hit;
		Debug.DrawRay(c.transform.position, c.transform.forward * 100f,Color.red,5f);
		if (Physics.Raycast(c.transform.position, c.transform.forward*100f, out hit))
		{
			print("Found " +hit.collider.gameObject.name +" - distance: " + hit.distance);

			pAnim.ShootAnimation();

			if (hit.collider.GetComponent<Player>() != null && hit.collider.GetComponent<Player>() != GetComponent<Player>())
				hit.collider.GetComponent<Player>().TakeDamage();
			

		}

		var muzzleParticleInstance = (GameObject)Instantiate(fireParticlePrefab,
		fireParticleSpawnPos.position,
		fireParticleSpawnPos.rotation);

		muzzleParticleInstance.transform.SetParent(transform);

		NetworkServer.Spawn(muzzleParticleInstance);


		Destroy(muzzleParticleInstance, fireCooldown + 0.2f);

	}
}
