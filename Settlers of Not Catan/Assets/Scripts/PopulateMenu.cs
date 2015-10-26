using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

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
    public List<string> maps; //temp array to hold maps
    public int active = 0;

    #endregion

    void Start() {
        //pull in default map
        using (StreamReader sr = new StreamReader(Application.dataPath + "/Embedded/Default.txt")) {
            maps.Add( sr.ReadLine());
        }

        string[] worlds = Directory.GetFiles(Application.dataPath + "/Worlds/", "*.txt");

        for(int i = 0; i < worlds.Length; i++) {
            using ( StreamReader sr = new StreamReader( worlds[i]) ) {
                maps.Add( sr.ReadLine() );
            }
        }


        //last update gui
        mapName.text = maps[0];
    }

    void Update() {
        if (maps.Count > 1) {
            if (active == 0) {
                back.gameObject.SetActive(false);
            } else if (active >= maps.Count - 1) {
                back.gameObject.SetActive(true);
                next.gameObject.SetActive(false);
            } else if (active > 0 && active < maps.Count) {
                back.gameObject.SetActive(true);
                next.gameObject.SetActive(true);
            }
        } else {
            back.gameObject.SetActive( false );
            next.gameObject.SetActive( false );
        }
    }

    public void NextButton() {
        UpdateSelectedMap(1);
    }

    public void BackButton() {
        UpdateSelectedMap(-1);
    }

    public void PlayButton() {
        
    }

    void UpdateSelectedMap(int i) {
        if (active + i > -1 && active + i < maps.Count) {
            active += i;
            mapName.text = maps[active];
        }
    }

}