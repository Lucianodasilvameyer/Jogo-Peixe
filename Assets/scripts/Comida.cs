using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comida : MonoBehaviour
{
    HabilidadesGeraisPlayer habilidadesGeraisPlayer;

    [SerializeField]
    Comida comida;

    public List<GameObject> ListComida = new List<GameObject>();
    // Start is called before the first frame update

    void Awake()
    {
        habilidadesGeraisPlayer = GameObject.Find("piranhaA").GetComponent<HabilidadesGeraisPlayer>();   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            habilidadesGeraisPlayer.GanharVida(habilidadesGeraisPlayer.recuperarVida);
            GuardarOuDestruirComida(comida.gameObject);

        }
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            GuardarOuDestruirComida(comida.gameObject);
        }
    }



    public void GuardarOuDestruirComida(GameObject gameObject)
    {
        if (comida.ListComida.Count > 0)
        {
            comida.ListComida.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
