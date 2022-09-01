using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] private Button _button;

	void Start()
	{
		//Button btn = button.GetComponent<Button>();
		_button.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
