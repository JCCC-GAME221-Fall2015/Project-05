using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: PopulateMenu populates the map menu based on maps in the directory
/// </summary>
public class PopulateMenu : MonoBehaviour {
    #region Fields

    public Text mapName;
    public Button next, back;
    public string[] maps; //temp array to hold maps
    public int active = 0;

    #endregion

    void Start() {}

    void Update() {
        if (active == 0) {
            back.gameObject.SetActive(false);
        } else if (active >= maps.Length - 1) {
            back.gameObject.SetActive(true);
            next.gameObject.SetActive(false);
        } else if (active > 0 && active < maps.Length) {
            back.gameObject.SetActive(true);
            next.gameObject.SetActive(true);
        }
    }

    public void NextButton() {
        UpdateSelectedMap(1);
    }

    public void BackButton() {
        UpdateSelectedMap(-1);
    }

    void UpdateSelectedMap(int i) {
        if (active + i > -1 && active + i < maps.Length) {
            active += i;
            mapName.text = maps[active];
        }
    }

}