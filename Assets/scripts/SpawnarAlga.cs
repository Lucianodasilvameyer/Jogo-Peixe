using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnarAlga : MonoBehaviour
{
    
    Alga alga;

    [SerializeField]
    int distanciaAlgaColisorFrente;

    public GameObject AlgaPrefab;

    [SerializeField]
    private Transform ColisorDaFrente_ref;

    //[SerializeField]
    private float SpawnarAlgaInicial;

    [SerializeField]
    private float SpawnarAlgaFinal;

    // Start is called before the first frame update
    void Awake()
    {
        alga = GameObject.Find("AlgaA").GetComponent<Alga>();   
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= SpawnarAlgaInicial + SpawnarAlgaFinal)
        {
            
            SpawnarAlgaInicial = Time.time;
            spawnarAlga();
            
        }
    }
    public void spawnarAlga()
    {
        Vector2 inipos = ColisorDaFrente_ref.transform.position;
        Vector2 position = inipos;
        position.x += distanciaAlgaColisorFrente;
        position.y += -7.9f;

        if (alga.ListAlgas.OfType<Alga>().Any())
        {
            int lugar = alga.ListAlgas.FindLastIndex(x => x.GetType() == typeof(Alga));
            GameObject Alga = alga.ListAlgas[lugar];
            alga.ListAlgas.RemoveAt(lugar);

            Alga.transform.position = position;
            Alga.SetActive(true);
        }
        else
        {
            GameObject go = Instantiate(AlgaPrefab, position, Quaternion.identity);
        }

        
    }  
}
