using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Grabs the informationSave Script from the gamecontroller object from 
/// the previous scene.
/// </summary>
public class GameInformation : MonoBehaviour {


	//public string lvlName;
	//public string userName;
    [HideInInspector]
	public InformationSave saveInfo;

    GameObject panelOptions;


	// Use this for initialization
	void Start ()
    {
        CheckForGameControllerObject();
    }

	/// <summary>
	/// Calls the save game function in the GameController Object from previous scene.
	/// </summary>
	public void _SaveGame()
	{
		saveInfo.SaveGame();
	}


    /// <summary>
    /// Checks to see if the GameController is present.
    /// Only will be if you started this scene from the create game scene.
    /// 
    /// Please add a game controller to load scene later and feed it the username and
    /// level name when loading.
    /// </summary>
    void CheckForGameControllerObject()
    {
        try
        {
            panelOptions = GameObject.Find("Panel_Options").gameObject;
            saveInfo = GameObject.Find("GameController").GetComponent<InformationSave>();
            
        }
        catch
        {
            if (panelOptions != null)
            {
                //If you test this scene without going through creating you can't save.
#if UNITY_EDITOR
                if (saveInfo == null)
                {
                    Debug.Log(">Disableing Save Button." +
                        "\nYou can't save if you load straight into this scene");
                    GameObject.Find("Button_SaveGame").GetComponent<Button>().interactable = false;
                }
#endif
            }
            else
            {
                Debug.Log("Please re-enable Panel_Options, can't find gameObject when" +
                    " disabled." +
                    "\nThis Script will handle disabling it at runtime.");
            }
            
        }
        finally
        {
            if(panelOptions != null)
            {
                panelOptions.gameObject.SetActive(false);
            }
        }
    }
}
