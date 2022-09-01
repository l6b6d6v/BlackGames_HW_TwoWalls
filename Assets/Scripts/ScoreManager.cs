using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color == collision.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            CubeManager.InstantiateCubeList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            _score++;
            _scoreText.text = _score.ToString();
        }
        else
        {
            collision.rigidbody.useGravity = true;
            collision.rigidbody.AddForce(gameObject.transform.position.x * (-0.3f), 0, 0, ForceMode.Impulse);
            Draggable.SelectedObject = null;
        }
    }
}