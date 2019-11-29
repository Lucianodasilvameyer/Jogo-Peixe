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


    private float intervaloSpawn=0;


    private float intervaloSpawnInicial;

    [SerializeField]
    private float intervaloSpawnMax;



    [SerializeField]
    float groundLevel;


    [SerializeField]
    float distanceEnemyFromPlayer;

    private float timerRespawnInimigos;

    [SerializeField]
    private float timerRespawnInimigosMax;
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
        if (Time.time >= intervaloSpawnInicial + intervaloSpawnMax && intervaloSpawn == 0)
        {
            intervaloSpawn = 1;  
        }
        if (Time.time >= timerRespawnInimigos + timerRespawnInimigosMax && intervaloSpawn==1)
        {
            

            timerRespawnInimigos = Time.time;

            intervaloSpawn = 0;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            position.x += distanceEnemyFromPlayer;
            position.y = groundLevel;// aqui o y é sempre o mesmo



            SpawnarInimigos<Isca>(1, 1, 6,Random.Range(-26, 19.137f), position);// o 1,6 são respectivamente a distanceMin e distanceMax entre os inimigos?
            SpawnarInimigos<Tubarao>(1, 1, 6, Random.Range(-26, 19.137f), position);
            SpawnarInimigos<RedePesca>(1, 1, 6, Random.Range(-26, 19.137f), position);
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float distanceMin, float distanceMax, float heightMax, Vector2 initialPos)
    {
        //if (!typeof(Y).IsSubclassOf(typeof(GameObject)))
            //return; 

            
            
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

                           Isca I = (Isca)ListInimigos[possicao];
                           ListInimigos.RemoveAt(possicao);

                           I.transform.position = position;
                           

                       }
                    }
                    /*else if (typeof(Y) == typeof(RedePesca))
                    {
                        if (ListInimigos.OfType<RedePesca>().Any())
                        {
                           int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(RedePesca));

                           RedePesca R = (RedePesca)ListInimigos[possicao];

                           ListInimigos.RemoveAt(possicao);

                           R.transform.position = position;
                           R.SetActive(true);
                          
                             
                        }
                    }*/
                    else if (typeof(Y) == typeof(Tubarao))
                    {
                         if (ListInimigos.OfType<Tubarao>().Any())
                         {
                              int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Tubarao));

                              Tubarao T = (Tubarao)ListInimigos[possicao];
                              ListInimigos.RemoveAt(possicao);

                              T.transform.position = position;

                                
                         } 
                    }
                }
                else
                {
                    if (typeof(Y) == typeof(Isca))
                    {
                        HabilidadesGeraisInimigo isca = Instantiate(iscaPrefab, position, Quaternion.identity).GetComponent<Isca>();
                    }
                    if (typeof(Y) == typeof(Tubarao))
                    {
                        HabilidadesGeraisInimigo Tubarao = Instantiate(tubaraoPrefab, position, Quaternion.identity).GetComponent<Tubarao>();    
                    }
                    /*if (typeof(Y) == typeof(RedePesca))
                    {
                        HabilidadesGeraisInimigo RedePesca = Instantiate(redeDePescaPrefab, position, Quaternion.identity).GetComponent<RedePesca>();
                    }*/
                }
                

                
            
        
    }
    public void adicionarOuDestruir(GameObject inimigo)                                         
    {
             
        if (ListInimigos.Count > 0)
        {
            ListInimigos.Add(inimigo);
        }
        else
        {
            Destroy(inimigo);
        }
    }
   



}
