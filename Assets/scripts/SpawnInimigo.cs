using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnInimigo : MonoBehaviour
{
    [SerializeField]
    private Transform LinhaDeSpawn;

    //public Transform LineStart,LineEnd;
    //public bool spawning = false;
    //public float spawnFrequency = 5f;
    //private float spawnTimer=0f;


    public GameObject tubaraoPrefab;
    public GameObject iscaPrefab;
    public GameObject redeDePescaPrefab;

    private float spawnarIscaInicial;

    [SerializeField]
    private float spawnarIscaMax;

    private float spawnarTubaraoInicial;

    [SerializeField]
    private float spawnarTubaraoMax;

    private float spawnarRedePescaInicial;

    [SerializeField]
    private float spawnarRedePescaMax;



    private float IscaIntervaloSpawn=0;


    private float IscaIntervaloSpawnInicial;

    [SerializeField]
    private float IscaIntervaloSpawnMax;


    private float TubaraoIntervaloSpawn = 0;


    private float TubaraoIntervaloSpawnInicial;

    [SerializeField]
    private float TubaraoIntervaloSpawnMax;

    private float RedePescaIntervaloSpawn = 0;


    private float RedePescaIntervaloSpawnInicial;

    [SerializeField]
    private float RedePescaIntervaloSpawnMax;


    //[SerializeField]
    //float groundLevel;

    


    [SerializeField]
    float distanceEnemyFromPlayer;

    //private float timerRespawnInimigos;

    //[SerializeField]
    //private float timerRespawnInimigosMax;
    [SerializeField]
    private Transform player_ref;

    [SerializeField]
    private Transform Camera;

    //public GameObject[] InimigoPrefab;


    List<GameObject> ListInimigos = new List<GameObject>();
    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        /*spawnTimer += Time.deltaTime;

        if(spawnTimer>= spawnFrequency)
        {
            spawn();
            spawnTimer = 0f;
        }*/
          
            
            
            
            
       
          
        if(Time.time>= IscaIntervaloSpawnInicial + IscaIntervaloSpawnMax && IscaIntervaloSpawn == 0)
        {
            IscaIntervaloSpawnInicial = Time.time;
            IscaIntervaloSpawn = 1;
        }
        if (Time.time >= spawnarIscaInicial + spawnarIscaMax && IscaIntervaloSpawn==1)
        {
            spawnarIscaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
           
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;

            
            SpawnarInimigos<Isca>(1, /*6, Random.Range(-1, 5),*/ position, position2);

            IscaIntervaloSpawn = 0;
        }

        if (Time.time >= TubaraoIntervaloSpawnInicial + TubaraoIntervaloSpawnMax && TubaraoIntervaloSpawn == 0)
        {
            TubaraoIntervaloSpawnInicial = Time.time;
            TubaraoIntervaloSpawn = 1;
        }
        if (Time.time >= spawnarTubaraoInicial + spawnarTubaraoMax && TubaraoIntervaloSpawn==1)
        {
            spawnarTubaraoInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            

            SpawnarInimigos<Tubarao>(5, /*6, Random.Range(-1, 5),*/ position, position2);

            TubaraoIntervaloSpawn = 0;
        }

        if(Time.time>= RedePescaIntervaloSpawnInicial+RedePescaIntervaloSpawnMax && RedePescaIntervaloSpawn == 0)
        {
            RedePescaIntervaloSpawnInicial = Time.time;
            RedePescaIntervaloSpawn = 1;
        }
        if (Time.time >= spawnarRedePescaInicial + spawnarRedePescaMax && RedePescaIntervaloSpawn==1)
        {
            spawnarRedePescaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            




            SpawnarInimigos<RedePesca>(1, /*6, Random.Range(-1, 5)*/ position, position2);

            RedePescaIntervaloSpawn = 0;
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, /*float distanceMax, float heightMax*/ Vector2 initialPos, Vector2 initialPos2)
    {
       

            
            
              
                Vector2 position = initialPos;
                position.x += Random.Range(5, 6);        /*distanceMax;*/                                                           //Random.Range(distanceMin, distanceMax);


                Vector2 position2 = initialPos2;
                position.y += Random.Range(-1,5);

        for (int i = 0; i < quantidadeIinimigos; i++)
        {

            if (ListInimigos.Count > 0)
            {
                if (typeof(Y) == typeof(Isca))
                {
                    if (ListInimigos.OfType<Isca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Isca));

                        GameObject Isca = ListInimigos[possicao];
                        ListInimigos.RemoveAt(possicao);




                        Isca.transform.position = position;
                        Isca.SetActive(true);


                    }
                }
                else if (typeof(Y) == typeof(RedePesca))
                {
                    if (ListInimigos.OfType<RedePesca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(RedePesca));

                        GameObject RedePesca = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);



                        RedePesca.transform.position = position;
                        RedePesca.SetActive(true);


                    }
                }
                else if (typeof(Y) == typeof(Tubarao))
                {
                    if (ListInimigos.OfType<Tubarao>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Tubarao));

                        GameObject tubarao = ListInimigos[possicao];
                        ListInimigos.RemoveAt(possicao);



                        tubarao.transform.position = position;
                        tubarao.SetActive(true);

                    }
                }
            }
            else
            {
                if (typeof(Y) == typeof(Isca))
                {
                    Isca GameObject = Instantiate(iscaPrefab, position, Quaternion.identity).GetComponent<Isca>();
                }
                if (typeof(Y) == typeof(Tubarao))
                {
                    Tubarao GameObject = Instantiate(tubaraoPrefab, position, Quaternion.identity).GetComponent<Tubarao>();
                }
                if (typeof(Y) == typeof(RedePesca))
                {
                    RedePesca GameObject = Instantiate(redeDePescaPrefab, position, Quaternion.identity).GetComponent<RedePesca>();
                }
            }

        }
                
            
        
    }
    public void adicionarOuDestruir(GameObject gameObject)                                         
    {
             
        if (ListInimigos.Count > 0)
        {
            ListInimigos.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*private void spawn()
    {
        float xrange = LineEnd.position.x - LineStart.position.x;
        float yrange = LineEnd.position.y - LineStart.position.y;

        Vector2 spawnLocation = new Vector2(LineStart.position.x + (xrange * UnityEngine.Random.value), LineStart.position.y + (yrange * UnityEngine.Random.value));
    }*/
    
  
   



}
