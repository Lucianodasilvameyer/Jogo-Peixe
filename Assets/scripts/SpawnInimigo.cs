﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    
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


    public GameObject[] InimigoPrefab;


    List<GameObject> ListInimigos = new List<GameObject>();
    Queue<Rede> Poolrede = new Queue<Rede>();
    
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



            SpawnarInimigos(1, 1, 6,Random.Range(-26, 19.137f), position);// o 1,6 são respectivamente a distanceMin e distanceMax entre os inimigos?
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float distanceMin, float distanceMax, float heightMax, Vector2 initialPos)
    {
        if (!typeof(Y).IsSubclassOf(typeof(GameObject))
        {

        

           for (int i = 0; i < quantidadeIinimigos; i++)
           {
              int index = Random.Range(0, InimigoPrefab.Length);//aqui o tamanho do array tem q ser igual a quantidade de inimigos?
              Vector3 position = initialPos;
              position.x += i * Random.Range(distanceMin, distanceMax);
              position.y += Random.Range(0, heightMax);
              position.z = -1f;

              if(ListInimigos.Count > 0)
              {
               Rede rede = Poolrede.Dequeue();
               rede.gameObject.SetActive(true);
              }

              GameObject go = Instantiate(InimigoPrefab[index], position, Quaternion.identity);
        }
    }
    public void destruirRede(Rede rede)
    {
             
        if (Poolrede.Count > 0)
        {
            Poolrede.Enqueue(rede);
        }
        else
        {
            Destroy(rede.gameObject);
        }
    }
   



}