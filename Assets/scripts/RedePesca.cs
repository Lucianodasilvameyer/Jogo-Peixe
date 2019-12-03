using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class RedePesca : MonoBehaviour
{
   

    [SerializeField]
    RedePesca Rede;

    [SerializeField]
    SpawnInimigo spawnInimigo_ref;

    

    

    

    

    

    // Start is called before the first frame update
    void Awake()
    {

        spawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            //Destroy(gameObject);
            spawnInimigo_ref.adicionarOuDestruir(Rede.gameObject);
        }
    }

}
