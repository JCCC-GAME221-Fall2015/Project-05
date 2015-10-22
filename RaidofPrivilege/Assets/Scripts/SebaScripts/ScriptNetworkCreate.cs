using UnityEngine;
using UnityEngine.Networking;


/// <summary>
/// @Author: Andrew Seba
/// @Description: Button to start game function.
/// </summary>
public class ScriptNetworkCreate : MonoBehaviour {

    public NetworkManager manager;

	
	public void _StartHost()
    {
        manager.StartHost();
    }
}
