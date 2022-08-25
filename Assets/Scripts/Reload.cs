using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Button button;

	void Start()
	{
		//Button btn = button.GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
