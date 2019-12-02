using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnInimigo : MonoBehaviour
{
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


    //public GameObject[] InimigoPrefab;


    List<GameObject> ListInimigos = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {


        


    }

    // Update is called once per frame
    void Update()
    {
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
            position.y = groundLevel;

            SpawnarInimigos<Isca>(1, 2, 5, Random.Range(-24, 14.137f), position);
        }
        if (Time.time >= spawnarTubaraoInicial + spawnarTubaraoMax)
        {
            spawnarTubaraoInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            position.y = groundLevel;

            SpawnarInimigos<Tubarao>(1, 3, 4, Random.Range(-22, 15.137f), position);
        }
        if (Time.time >= spawnarRedePescaInicial + spawnaRedePescaMax)
        {
            spawnarRedePescaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            position.y = groundLevel;

            SpawnarInimigos<RedePesca>(1, 1, 6, Random.Range(-12, 14.137f), position);
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float distanceMin, float distanceMax, float heightMax, Vector2 initialPos)
    {
       

            
            
                //int index = Random.Range(0, InimigoPrefab.Length);//aqui o tamanho do array tem q ser igual a quantidade de inimigos?
                Vector3 position = initialPos;
                position.x += Random.Range(distanceMin, distanceMax);
                position.y += Random.Range(0, heightMax);
                position.z = -1f;

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
    
   



}
