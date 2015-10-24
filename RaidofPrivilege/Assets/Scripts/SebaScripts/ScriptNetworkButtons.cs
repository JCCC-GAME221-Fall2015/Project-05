using UnityEngine;
using UnityEngine.Networking;


/// <summary>
/// @Author: Andrew Seba
/// @Description: Button to start game function.
/// </summary>
public class ScriptNetworkButtons : MonoBehaviour {

    public NetworkManager manager;

    public void _Connect()
    {
        manager.StartClient();
    }
	
	public void _StartHost()
    {
        manager.StartHost();
    }
}
