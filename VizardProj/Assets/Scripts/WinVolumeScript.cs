using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolumeScript : MonoBehaviour
{
    public SceneTransitionScripts loadMenuScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loadMenuScript.LoadNextLevel();

        }

    }
}
