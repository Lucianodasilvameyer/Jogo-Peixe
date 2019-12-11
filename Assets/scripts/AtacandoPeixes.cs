using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacandoPeixes : MonoBehaviour
{
    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo;

    [SerializeField]
    HabilidadesGeraisPlayer HGP_ref;


    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisInimigo = GetComponent<HabilidadesGeraisInimigo>();

        HGP_ref = GameObject.Find("piranhaA").GetComponent<HabilidadesGeraisPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("acertou");

            HGP_ref.Damage(habilidadesGeraisInimigo.strength);

            //habilidadesGeraisInimigo.CausarDano(collision.GetComponent<Player>());

            /*var Player = collision.gameObject.GetComponent<Player>();

            if(Player != null)
            {
                Debug.Log("acertou");
                habilidadesGeraisInimigo_ref.CausarDano();
            }*/
        }
    }
}
