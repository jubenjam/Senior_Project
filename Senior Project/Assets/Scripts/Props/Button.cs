using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public Sprite released;
    public Sprite pressed;
    SpriteRenderer m_SpriteRenderer;

    public UnityEvent OnPressedEvent;
    public UnityEvent OnReleasedEvent;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pushable")
        {
            m_SpriteRenderer.sprite = pressed;
            OnPressedEvent.Invoke();
        }
    } 

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pushable")
        {
            m_SpriteRenderer.sprite = released;
            OnReleasedEvent.Invoke();
        }
    } 
}
