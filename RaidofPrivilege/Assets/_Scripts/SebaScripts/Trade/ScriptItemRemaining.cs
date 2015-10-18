using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Is the actual button being instantiated.
/// </summary>
[System.Serializable]
public class ScriptItemRemaining : MonoBehaviour {

    public string resourceName;
    public int resourceAmount;
    public Button.ButtonClickedEvent thingToDo;

    public ScriptItemRemaining(string pName, int pResourceAmount)
    {
        resourceName = pName;
        resourceAmount = pResourceAmount;
    }
}