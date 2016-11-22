using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour
{
	[SyncVar(hook = "OnChangeHealth")]
	public int health = 5;


	private int maxHealth = 5;
	[SyncVar(hook = "OnChangeAlive")]
	public bool alive = true;
	[SyncVar(hook = "OnChangeKD")]
	private int deaths = 0;
	[SyncVar(hook = "OnChangeKD")]
	public int kills = 0;

	public Image healthBar;
	public Text kdText;
	private PlayerMotor m;

	private PlayerAnimations pAnim;
	public int winKills = 5;

	private float cooldownTimer = -1f;
	private float cooldown = 1f;

	void Start()
	{
		pAnim = GetComponent<PlayerAnimations>();
		m = GetComponent<PlayerMotor>();
	}


	public void TakeDamage()
	{
		health--;
		Debug.Log("<color=red>Player took damage</color>");

	}

	void Die()
	{
		pAnim.DeathAnimation();
	}

	void Update() {
		if (cooldownTimer > 0)
			cooldownTimer -= Time.deltaTime;
	}

	void OnChangeAlive(bool yesno) {
	
		

		cooldownTimer = cooldown;

		Debug.Log("On change alive is called..");
		
		Player[] players = FindObjectsOfType<Player>();

		for (int i = 0; i < players.Length; i++)
		{

			if (players[i] == this && isLocalPlayer)
				deaths++;

		}
		OnChangeKD(0);

	}

	private void OnChangeKD(int i)
	{
		kdText.text =  "Deaths: " + deaths;

		if (kills >= winKills) {
			FindObjectOfType<Prototype.NetworkLobby.LobbyManager>().ServerChangeScene("WinScene");
			SceneManager.LoadScene("WinScene");
		}

		if (deaths >= winKills)
		{
			FindObjectOfType<Prototype.NetworkLobby.LobbyManager>().ServerChangeScene("LoseScene");
			SceneManager.LoadScene("LoseScene");
		}


	}

	void OnChangeHealth(int health)
	{
		healthBar.fillAmount = (float)((float)Mathf.Clamp(health, 0, maxHealth) / (float)maxHealth);
		if (health <= 0 && alive)
		{
			alive = false;
			Die();

			m.Disable();

			
			GetComponent<Collider>().enabled = false;

			Respawn();

			Debug.Log("<color=red>Player is DEAD</color>");
		}
	}

	void Respawn()
	{

		StartCoroutine(RespawnCoroutine());

	}

	private IEnumerator RespawnCoroutine()
	{
		yield return new WaitForSeconds(2f);
		
		GetComponent<Collider>().enabled = true;
		pAnim.RespawnAnimation();
		this.health = maxHealth;
		alive = true;

		NetworkStartPosition[] spawnPoints = GameObject.FindObjectsOfType<NetworkStartPosition>();

		transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].transform.position;
	
	}
}
