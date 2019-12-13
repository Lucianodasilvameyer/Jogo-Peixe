using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpawnarComida : MonoBehaviour
{
    Comida comida;

    [SerializeField]
    private float distanciaComidaPlayer;

    [SerializeField]
    private Transform Player_ref;

    [SerializeField]
    private Transform ColisorDaFrente;

 

    public GameObject comidaPrefab;

    private float timerSpawnComida;

    [SerializeField]
    private float timerSpawnComidaMax;

    // Start is called before the first frame update
    void Awake()
    {
        comida = GameObject.Find("comidaDePeixe").GetComponent<Comida>();    
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timerSpawnComida + timerSpawnComidaMax)
        {
            timerSpawnComida = Time.time;

            Vector2 inipos = Player_ref.transform.position;
            Vector2 Position = inipos;
            Position.x = distanciaComidaPlayer;

            Vector2 iniposColisor = ColisorDaFrente.transform.position;
            Vector2 Position2 = iniposColisor;

            SpawnComida(1, Position, Position2);
            

        
        } 
    }
    public void SpawnComida(int quantidadeComida, Vector2 inipos1, Vector2 inipos2)
    {
        Vector2 Position = inipos1;
        Position.x += 5;

        Vector2 Position2 = inipos2;
        Position.y += Random.Range(-1, 5);

        if (comida.ListComida.OfType<Comida>().Any())
        {
            int lugar = comida.ListComida.FindLastIndex(x => x.GetType() == typeof(Comida));
            GameObject comidaAchada = comida.ListComida[lugar];
            comida.ListComida.RemoveAt(lugar);

            comidaAchada.transform.position = Position;
            comidaAchada.SetActive(true);

        }
        else
        {
            GameObject Ve = Instantiate(comidaPrefab, Position, Quaternion.identity);
        }
    }
   
    

    
}
