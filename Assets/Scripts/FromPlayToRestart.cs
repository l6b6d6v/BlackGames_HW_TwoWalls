using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromPlayToRestart : MonoBehaviour
{
    [SerializeField] private GameObject _restartCanvas;

    // Update is called once per frame
    void Update()
    {
        if (CubeManager.InstantiateCubeList.Count == 0)
        {
            gameObject.SetActive(false);
            _restartCanvas.SetActive(true);
        }
    }
}
