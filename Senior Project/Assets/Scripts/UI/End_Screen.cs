using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End_Screen : MonoBehaviour
{
    public TextMeshProUGUI TextScore;

    // Start is called before the first frame update
    void Start()
    {
        TextScore.text = PlayerMovement.score.ToString()+"/1100";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            PlayerMovement.score = 0;
            SceneManager.LoadScene(0);
        }
    }
}
