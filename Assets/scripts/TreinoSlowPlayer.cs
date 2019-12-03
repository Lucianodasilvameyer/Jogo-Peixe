using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreinoSlowPlayer : MonoBehaviour
{
    PlayerMovimentacao playerMovimentacao;

    [SerializeField]
    private float velocidadeLentaInicial;

    [SerializeField]
    private float velocidadeLentaMax;

    public int perder;

    public int recuperar;

    public bool slow=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(slow)
       {
            velocidadeLentaInicial += Time.deltaTime;
       }
       if (velocidadeLentaInicial >= velocidadeLentaMax && slow==true)
       {
            playerMovimentacao.speed += recuperar;
            velocidadeLentaInicial = 0;
            slow = false;
       }
    }
    public void Devagar()
    {
        Lentidao(perder);
    }
    public void Lentidao(int lento)
    {
        playerMovimentacao.speed -= lento;
        slow = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedeDepesca"))
        {
            Destroy(collision.gameObject);
            Devagar();
        }
    }
}
