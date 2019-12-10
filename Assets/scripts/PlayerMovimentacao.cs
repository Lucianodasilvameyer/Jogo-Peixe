using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    

  

    public Rigidbody2D rigidbody2D_;
    public float speed;
    public Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D_ = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get_Input();
    }
    private void FixedUpdate()
    {
        Vector2 Position = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidbody2D_.velocity = Position * speed;

       if(Position.x > 0 || Position.x < 0 || Position.y > 0 || Position.y < 0)
       {
            animator.SetBool("Walking",true);
       }
       else
       {
            animator.SetBool("Walking", false);
       }
    }
    //void get_Input()
    /*{
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D_.velocity = new Vector2(speed, rigidbody2D_.velocity.x);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector3(1, 1, 1);



        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D_.velocity = new Vector2(-speed, rigidbody2D_.velocity.x);
            animator.SetBool("Moving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rigidbody2D_.velocity = new Vector2(0, 0);
            animator.SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // righ.velocity = new Vector2(speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //righ.velocity = new Vector2(speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            //righ.velocity = new Vector2(speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            //righ.velocity = new Vector2(speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(1, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            //righ.velocity = new Vector2(-speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            //righ.velocity = new Vector2(-speed, righ.velocity);
            animator.SetBool("GhostFadeOut", true);
            transform.localScale = new Vector2(-1, -1);
        }

    }*/
    
}
