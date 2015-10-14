using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableDebugText : MonoBehaviour {

	public Text[] debugStuff;

	// Use this for initialization
	void Start () {

#if UNITY_EDITOR

#else
		foreach(Text text in debugStuff)
		{
			text.gameObject.SetActive(false);
		}
#endif
	}
}
