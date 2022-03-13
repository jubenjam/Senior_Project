using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Controller : MonoBehaviour
{

    public SpriteRenderer doorSprite;
    public Sprite openDoor;
    public Sprite closedDoor;
    bool open = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (open && Input.GetButton("Interact")) {
                SceneManager.LoadScene("Title Scene");
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