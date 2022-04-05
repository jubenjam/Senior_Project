using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;
        PauseMenu.Pausable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
            PauseMenu.Pausable = true;
        }
    }
}
