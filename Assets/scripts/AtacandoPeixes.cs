using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacandoPeixes : MonoBehaviour
{
    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo;
    


    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisInimigo = GetComponent<HabilidadesGeraisInimigo>();    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("acertou");
            habilidadesGeraisInimigo.CausarDano(collision.GetComponent<Player>());

            /*var Player = collision.gameObject.GetComponent<Player>();

            if(Player != null)
            {
                Debug.Log("acertou");
                habilidadesGeraisInimigo_ref.CausarDano();
            }*/
        }
    }
}
