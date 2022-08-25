using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromPlayToRestart : MonoBehaviour
{
    public GameObject restartCanvas;

    // Update is called once per frame
    void Update()
    {
        if (CubeManager.InstantiateCubeList.Count == 0)
        {
            gameObject.SetActive(false);
            restartCanvas.SetActive(true);
        }
    }
}
