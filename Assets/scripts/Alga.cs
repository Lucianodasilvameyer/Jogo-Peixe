using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Alga : MonoBehaviour
{
    
    
    [SerializeField]
    Alga alga;

    public List<GameObject> ListAlgas = new List<GameObject>();

    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            GuardarOuDestruir(alga.gameObject);
        }
    }
    public void GuardarOuDestruir(GameObject gameObject)
    {
        if(ListAlgas.Count > 0)
        {
            ListAlgas.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 }
