using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubarao : HabilidadesGeraisInimigo
{
    [SerializeField]
    Tubarao Shark;

    [SerializeField]
    SpawnInimigo spawnInimigo_ref;

    void Awake()
    {
        spawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        habilidadesGeraisPlayer = GameObject.Find("Traira").GetComponent<HabilidadesGeraisPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            spawnInimigo_ref.adicionarOuDestruir(Shark.gameObject);
        }
    }


}





