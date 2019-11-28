using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rede : MonoBehaviour
{
    [SerializeField]
    Rede rede;

    [SerializeField]
    SpawnInimigo spawnInimigo_ref;

    [SerializeField]
    PlayerMovimentacao playerMovimentacao_ref;

    public float strength;
    public float recuperacao;

    public bool devagar = false;

    [SerializeField]
    private float velocidadeLentaInicial;

    [SerializeField]
    private float velocidadeLentaMax;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time>= velocidadeLentaInicial+velocidadeLentaMax && devagar == true)
       {

            devagar = false;
            playerMovimentacao_ref.speed += (int)recuperacao;

            velocidadeLentaInicial = Time.time;

            
        } 
    }
    public void desacelerar(int prender)
    {
        playerMovimentacao_ref.speed -= prender;
        devagar = true;
    }
    public void lentidao(Player alvo)
    {
        desacelerar((int)strength);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDetras"))
        {
            spawnInimigo_ref.destruirRede(rede);
        }
    }

}
