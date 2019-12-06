using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    public float speed;
    public Rigidbody2D righ;
    public Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        righ = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 Position = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        righ.velocity = Position * speed;
    }
    void get_Input()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //righ.velocity = new Vector2(speed, righ.velocity);
            //animator.SetBool();
        }
    }
}
