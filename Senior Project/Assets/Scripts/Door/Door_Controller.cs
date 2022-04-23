using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Controller : MonoBehaviour
{

    public SpriteRenderer doorSprite;
    public Sprite openDoor;
    public Sprite closedDoor;
    public bool open = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (open && Input.GetButton("Interact")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
  
    public void OpenDoor()
    {
        open = true;
        doorSprite.sprite = openDoor;
    }
    public void CloseDoor()
    {
        open = false;
        doorSprite.sprite = closedDoor;
    }
}
