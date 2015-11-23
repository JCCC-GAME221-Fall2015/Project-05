using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: MenuTransitions allows for transitioning between scenes
/// </summary>
public class MenuTransitions : MonoBehaviour {
    #region Fields

    #endregion

    public static void MapSelect() {
        Application.LoadLevel("SceneMapSelect");
    }

}