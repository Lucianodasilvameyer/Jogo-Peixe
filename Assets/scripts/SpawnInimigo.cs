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
    private float spawnaRedePescaMax;



    //private float intervaloSpawn=0;


    //private float intervaloSpawnInicial;

    //[SerializeField]
    //private float intervaloSpawnMax;



    [SerializeField]
    float groundLevel;

    


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
          
            
            
            
            
            
        /*if (Time.time >= intervaloSpawnInicial + intervaloSpawnMax && intervaloSpawn == 0)
          {
             intervaloSpawn = 1;  
          }
          if (Time.time >= timerRespawnInimigos + timerRespawnInimigosMax && intervaloSpawn==1)
          */

            

        if (Time.time >= spawnarIscaInicial + spawnarIscaMax)
        {
            spawnarIscaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
           
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            





            SpawnarInimigos<Isca>(2, 2, 5, Random.Range(0, 5), position, position2);
        }
        if (Time.time >= spawnarTubaraoInicial + spawnarTubaraoMax)
        {
            spawnarTubaraoInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            

            SpawnarInimigos<Tubarao>(5, 3, 4, Random.Range(0, 5), position, position2);
        }
        if (Time.time >= spawnarRedePescaInicial + spawnaRedePescaMax)
        {
            spawnarRedePescaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            




            SpawnarInimigos<RedePesca>(1, 1, 6, Random.Range(0, 5), position, position2);
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float distanceMin, float distanceMax, float heightMax, Vector2 initialPos, Vector2 initialPos2)
    {
       

            
            
              
                Vector2 position = initialPos;
                position.x += Random.Range(distanceMin, distanceMax);
                
                Vector2 position2 = initialPos2;
                position.y += Random.Range(-6, heightMax);
              
                if (ListInimigos.Count > 0)
                {
                    if (typeof(Y) == typeof(Isca))
                    {
                       if (ListInimigos.OfType<Isca>().Any())
                       {
                           int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Isca));

                           GameObject Isca  = ListInimigos[possicao];
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
                        Isca GameObject  = Instantiate(iscaPrefab, position, Quaternion.identity).GetComponent<Isca>();
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
