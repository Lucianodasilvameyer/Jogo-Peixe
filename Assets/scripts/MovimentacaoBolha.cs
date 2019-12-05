using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoBolha : MonoBehaviour
{
    [SerializeField]
    CameraComLimites cameraComLimites_ref;


    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movimento();
    }
    public void movimento()
    {
        Vector2 Input = new Vector2(0, 2);
        Vector2 Direction = Input.normalized;
        Vector2 Velocity = cameraComLimites_ref.speed * Direction;
        Velocity.y = body.velocity.y;
        body.velocity = Velocity;

    }
}
