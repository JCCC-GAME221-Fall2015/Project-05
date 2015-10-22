using UnityEngine;
using UnityEngine.Networking;

public class ScriptPlayerNetworkSetup : NetworkBehaviour {


    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<ScriptPlayer>().enabled = true;
        }
    }
}
