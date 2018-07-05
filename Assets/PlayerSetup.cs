using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] scriptsToDisable;

    Camera sceneCam;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            foreach (var item in scriptsToDisable)
            {
                item.enabled = false;
            }
        }
        else
        {
            sceneCam = Camera.main;
            if(sceneCam)
                Camera.main.gameObject.SetActive(false);
        }
	}

    void OnDisable()
    {
        if (sceneCam)
            sceneCam.gameObject.SetActive(true);
    }
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
