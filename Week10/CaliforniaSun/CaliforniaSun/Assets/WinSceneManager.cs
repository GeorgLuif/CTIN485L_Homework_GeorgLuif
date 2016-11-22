using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{

	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	public void ReturnLobby()
	{
		Application.Quit();
	}

}
