using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text blueScoreText;
    public TMP_Text redScoreText;
    private int blueScore = 0;
    private int redScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        blueScoreText.text = blueScore.ToString();
        redScoreText.text = redScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "BlueWall")
        {
            if (collision.gameObject.CompareTag("blueCube"))
            {
                CubeManager.InstantiateCubeList.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                blueScore++;
                blueScoreText.text = blueScore.ToString();
            }
            if (collision.gameObject.CompareTag("redCube"))
            {
                collision.rigidbody.useGravity = true;
                collision.rigidbody.AddForce(gameObject.transform.position.x * (-0.3f), 0, 0, ForceMode.Impulse);
                Draggable.selectedObject = null;
            }

        }
        else
        if (gameObject.name == "RedWall")
        {
            if (collision.gameObject.CompareTag("redCube"))
            {
                CubeManager.InstantiateCubeList.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                redScore++;
                redScoreText.text = redScore.ToString();
            }
            if (collision.gameObject.CompareTag("blueCube"))
            {
                collision.rigidbody.useGravity = true;
                collision.rigidbody.AddForce(gameObject.transform.position.x * (-0.3f), 0, 0, ForceMode.Impulse);
                Draggable.selectedObject = null;
            }
        }
        return;
    }
}