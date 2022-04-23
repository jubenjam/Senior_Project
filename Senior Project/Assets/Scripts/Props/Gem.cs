using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value = 100;
    void OnEnable()
    {
        value = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
            PlayerMovement.score += value;
            pm.scoreThisScene += value;
            value = 0;
            gameObject.SetActive(false);
        }
    }
}
