using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
	[SyncVar]
	public string playerName = "unnamed";

	TextMesh nameMesh;

	void OnGUI()
	{

		if (isLocalPlayer)
		{
			playerName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), playerName);

			if(GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "change")) {
				CmdChangeName(playerName);
			}

		}
	}

	void Start()
	{
		if (isLocalPlayer)
			GetComponent<PlayerMotor>().enabled = true;

		nameMesh = GetComponentInChildren<TextMesh>();
	}

	[Command]
	public void CmdChangeName(string newName) {
		playerName = newName;
	}


	void Update()
	{
		if (isLocalPlayer)
			nameMesh.text = playerName;
	}


}
