using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool crouch = false;
    bool moveInput = false;
    public SpriteRenderer playerSprite;
    Color defaultColor;
    public UnityEvent OnDeathEvent;
    public BoxCollider2D topOfCharacter;

    public TextMeshProUGUI TextScore;
    public static int score = 0;
    public int scoreThisScene = 0;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        defaultColor = playerSprite.color;
        TextScore.transform.position = new Vector3(Screen.width, Screen.height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = score.ToString();
        if(!PauseMenu.GameIsPaused && PauseMenu.Pausable)
        {
            moveInput = false;
            //get horizontal movement
            horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

            if(horizontalMovement != 0)
            {
                moveInput = true;
            }
            //check for jumping
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                moveInput = true;
                animator.SetBool("IsJumping", true);
            }
            //check for crouching    
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
                topOfCharacter.enabled = false;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
                topOfCharacter.enabled = true;
            }
            if (Input.GetButtonDown("Reset"))
            {
                Die();
            }
        }

    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    // FixedUpdate is called a fixed amount of times per second
    void FixedUpdate()
    {
        //Move character (fixedDeltaTime makes sure movement is at same speed on different computers)
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false; //don't jump forever
    }

    private void Die()
    {
        transform.position = new Vector3(0, 0, 0);
        StartCoroutine(Blink());
        score -= scoreThisScene;
        scoreThisScene = 0;
        OnDeathEvent.Invoke();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Stairs"))
        {
            if(moveInput == true)
            {   //normal movement
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {   //prevent from slipping down stairs
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }    

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Stairs"))
        {   //return to normal movement
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private IEnumerator Blink() 
    { 
        for(int i=0; i < 3; i++){
            playerSprite.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.2f);
            playerSprite.color = defaultColor;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
