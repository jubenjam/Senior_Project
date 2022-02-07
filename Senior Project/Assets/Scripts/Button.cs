using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite released;
    public Sprite pressed;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pushable")
        {
            m_SpriteRenderer.sprite = pressed;
        }
    } 

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pushable")
        {
            m_SpriteRenderer.sprite = released;
        }
    } 
}
