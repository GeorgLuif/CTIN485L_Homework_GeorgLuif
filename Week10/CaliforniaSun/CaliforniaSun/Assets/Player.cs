using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Player : NetworkBehaviour
{
	[SyncVar(hook = "OnChangeHealth")]
	public int health = 5;


	private int maxHealth = 5;
	[SyncVar]
	public bool alive = true;

	public Image healthBar;

	private PlayerAnimations pAnim;

	void Start()
	{
		pAnim = GetComponent<PlayerAnimations>();
	}


	public void TakeDamage()
	{
		if (!isServer)
			return;

		health--;
		Debug.Log("<color=red>Player took damage</color>");
		

		if(health <= 0 && alive)
		{
			alive = false;
			RpcDie();
		}

	}


	[ClientRpc]
	void RpcDie()
	{
		if (!isLocalPlayer)
			return;

		Debug.Log("<color=black>Player DIED</color>");
		pAnim.DeathAnimation();
	}

	void OnChangeHealth(int health)
	{
		healthBar.fillAmount = (float)((float)Mathf.Clamp(health, 0, maxHealth) / (float)maxHealth);
	}
}
