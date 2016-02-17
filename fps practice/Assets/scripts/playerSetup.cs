using UnityEngine;
using UnityEngine.Networking;

public class playerSetup : NetworkBehaviour {

    public Behaviour[] compToDisable;

    Camera sceneCamera;

	void Start ()
    {
        if(!isLocalPlayer)
        {
            for (int i = 0; i < compToDisable.Length; i++)
            {
                compToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
            

        }
	}

    void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
