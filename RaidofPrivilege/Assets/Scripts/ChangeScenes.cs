using UnityEngine;
using System.Collections;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Basic change to scene script.
/// </summary>
public class ChangeScenes : MonoBehaviour {

	public void _MainScene()
	{
		Application.LoadLevel("MainGame");
	}

    public void _CreateGameScene()
    {
        Application.LoadLevel("CreateGameScene");
    }

    public void _QuitGame()
    {
        Application.Quit();
    }
}
