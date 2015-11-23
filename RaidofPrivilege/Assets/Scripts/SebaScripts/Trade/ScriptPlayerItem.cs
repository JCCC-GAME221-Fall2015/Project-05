using UnityEngine.UI;


/// <summary>
/// @Author: Andrew Seba
/// @Description: Dynamic Player Select Button Item.
/// </summary>
[System.Serializable]
public class ScriptPlayerItem {

    public string playerName;

    public Button.ButtonClickedEvent choosePlayer;

    public ScriptPlayerItem(string pPlayerName)
    {
        playerName = pPlayerName;
    }
}
