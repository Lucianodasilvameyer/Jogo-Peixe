using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesGeraisInimigo : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip somCausarDano;
    AudioClip somTomarDano;

    [SerializeField]
    HabilidadesGeraisPlayer habilidadesGeraisPlayer_ref;

    
    public float strength; 

    

    [SerializeField]
    float speed;

    [SerializeField]
    private Vector2 direction;

    

    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisPlayer_ref = GameObject.Find("Traira").GetComponent<HabilidadesGeraisPlayer>(); 
        //DefinirAlvo();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    public void Mover()
    {
       
        transform.Translate(speed* direction* Time.deltaTime);
    }

    

    /*internal void CausarDano(Cascudo cascudo)
    {
        throw new NotImplementedException();
    }

    internal void CausarDano(CascudoArmadura cascudoArmadura)
    {
        throw new NotImplementedException();
    }*/

    /*public void DefinirAlvo()
    {
        if(!target || target == null)
        {
            //target = GameObject.FindGameObjectWithTag("Cascudo").transform;
            target = GameObject.FindGameObjectWithTag("Player").transform;

            
        }
        direction = target.position - transform.position; //pq o direction tem q ir fora do if?
        direction = direction.normalized;
    }*/

    public void CausarDano(Player alvo)
    {
        habilidadesGeraisPlayer_ref.TomarDano((int)strength);


    }
    public void SomPlay(AudioClip Som)
    {
        audioSource.clip = Som;
        audioSource.Play();
    }
}
