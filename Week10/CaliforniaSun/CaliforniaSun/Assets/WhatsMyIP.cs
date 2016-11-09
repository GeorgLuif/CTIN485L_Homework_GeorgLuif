using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhatsMyIP : MonoBehaviour
{
	public Text ipText;

	void Start() {
		string IP = "IP adress: ";
		IP += Network.player.ipAddress;
		ipText.text = IP;
	}
	
	
}
