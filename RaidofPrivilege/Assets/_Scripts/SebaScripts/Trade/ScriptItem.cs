using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Is the actual button being instantiated.
/// </summary>
[System.Serializable]
public class ScriptItem {

    public string resourceName;
    public int resourceAmount;
    public Button.ButtonClickedEvent thingToDo;

    public ScriptItem(string pName, int pResourceAmount)
    {
        resourceName = pName;
        resourceAmount = pResourceAmount;
    }
}