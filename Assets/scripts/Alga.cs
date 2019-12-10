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

    public GameObject AlgaPrefab;

    [SerializeField]
    private Transform ColisorDaFrente;

    List<GameObject> ListAlgas = new List<GameObject>();

    private float SpawnarAlgaInicial;

    [SerializeField]
    private float SpawnarAlgaFinal;

    // Start is called before the first frame update
   
   



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= SpawnarAlgaInicial + SpawnarAlgaFinal)
        {
            SpawnarAlgaInicial = Time.time;
            SpawnarAlga();
        }

        
    }
    public void SpawnarAlga()
    {
        Vector2 inicialPosColisorFrente = ColisorDaFrente.transform.position;
        Vector2 position = inicialPosColisorFrente;
        position.x = 2;
        position.y = 3;

        if (ListAlgas.OfType<Alga>().Any())
        {
            int lugar = ListAlgas.FindLastIndex(x => x.GetType() == typeof(Alga));
            GameObject Alga = ListAlgas[lugar];
            ListAlgas.RemoveAt(lugar);

            Alga.transform.position = position;
            Alga.SetActive(true);
        }
        else
        {
            GameObject go = Instantiate(AlgaPrefab, position, Quaternion.identity);
        }

        
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
