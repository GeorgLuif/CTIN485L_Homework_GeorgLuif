using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
	[SyncVar]
	public string playerName = "unnamed";
    public Camera camera;
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
        camera.enabled = false;
		GetComponentInChildren<MouseLook>().enabled = false;
		GetComponentInChildren<AudioListener>().enabled = false;
		GetComponentInChildren<Player_Gun>().enabled = false;

		if (isLocalPlayer)
        {
            camera.enabled = true;
			GetComponent<PlayerMotor>().enabled = true;
			GetComponentInChildren<MouseLook>().enabled = true;
			GetComponentInChildren<AudioListener>().enabled = true;
			GetComponentInChildren<Player_Gun>().enabled = true;
		}

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
