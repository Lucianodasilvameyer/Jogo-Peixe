using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class RedePesca : MonoBehaviour
{
    HabilidadesGeraisPlayer habilidadesGeraisPlayer;

    [SerializeField]
    RedePesca Rede;

    [SerializeField]
    SpawnInimigo spawnInimigo_ref;

    

    public float strength;
    

    

    

    

    // Start is called before the first frame update
    void Awake()
    {
        spawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        habilidadesGeraisPlayer = GameObject.Find("Traira").GetComponent<HabilidadesGeraisPlayer>();
        //playerMovimentacao_ref = GameObject.Find("Traira").GetComponent<PlayerMovimentacao>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            Destroy(gameObject);
            //spawnInimigo_ref.adicionarOuDestruir(Rede.gameObject);
        }
    }

}
