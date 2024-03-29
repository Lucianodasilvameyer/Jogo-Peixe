﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesGeraisPlayer : MonoBehaviour  
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip somCausarDano;

    [SerializeField]
    TempoParaComer tempoParaComer;

    Interface interface_ref;
    // Start is called before the first frame update
    void Awake()
    {
        interface_ref = GetComponent<Interface>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Comer()
    {
        tempoParaComer.Contagem += 5;
    }
    public void TomarDano(int dano)
    {
        interface_ref.HP -= dano;
    }
    public void SomPlay(AudioClip Som)
    {
        audioSource.clip = Som;
        audioSource.Play();
    }

    public void Damage(int dano)
    {
        interface_ref.HP -= dano;
    }
}
