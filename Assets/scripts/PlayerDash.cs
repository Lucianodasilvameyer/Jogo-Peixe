﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    Ghost ghost;
    

    SpawnarBolhas spawnarBolha;

    EfeitoCorridaPlayer efeitoCorridaPlayer;

    Rigidbody2D righ;
    public int dashSpeed;
    public int maxDashes;   //Numero maximo de dashes

    //[SerializeField]
    //CoolDownDoubleDash coolDownDoubleDash;

    public int dashes;                    //Contador de dashes
    [SerializeField] float timer = 0;               //Variavel que funcionará como cronometro
    [SerializeField] float dashCooldown = 6f;       //Cooldown da habilidade de dash
    [SerializeField] float dashDelay = 0.35f;       //Intervalo entre o double dash

    public bool dashEnabled = true;

    // Start is called before the first frame update

    private void Awake()
    {
        spawnarBolha = GetComponent<SpawnarBolhas>();
        righ = GetComponent<Rigidbody2D>();
        efeitoCorridaPlayer = GetComponent<EfeitoCorridaPlayer>();
        ghost = GetComponent<Ghost>();

    }

    private void Start()
    {
        dashes = maxDashes;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       
       if (Input.GetKeyDown(KeyCode.Space))
       {

           if (dashes > 0 && dashEnabled)
           {
                Dash(x, y);

               if (ghost.ghostDelaySeconds > 0)
               {
                    ghost.ghostDelaySeconds -= Time.deltaTime; 
               }
               else
               {
                    GameObject currentGhost = Instantiate(ghost.ghost, transform.position, transform.rotation);
                    ghost.ghostDelaySeconds = ghost.ghostDelay;
                    
               }

                   
           }
       }
    }

    public void Dash(float x, float y)
    {
        Debug.Log("Dashing");

        Vector2 direction = new Vector2(x, y);

        righ.AddForce(direction * dashSpeed, ForceMode2D.Impulse);//força e modo respectivamente? no caso o direction vira um vetor ao ser adicionado força a ele         
                                                         //dentro do parametro do righ.Addforce deve vir respectivamente um vetor e um modo?
        dashEnabled = false;

        dashes--;

        StopCoroutine("DashReload");
        StartCoroutine("DashReload");

        spawnarBolha.SpawnarBolha();

        //GameObject ro = Instantiate(efeitoCorridaPlayer.EfeitoCorrer, transform.position, transform.rotation);
    }

    IEnumerator DashReload() //o IEnumerator espera um certo tempo para executar uma coisa
    {
        //Seta o valor do contador para zero
        timer = 0;     
        //Enquanto o valor de "timer" for menor que o cooldown do dash
        while(timer <= dashCooldown)//o while vai rodar 10 segundos não 10 vezes
        {
            Debug.Log(Time.fixedDeltaTime);//o Time.fixedDeltaTime repete um valor diferente a cada frame, ja o Time.deltaTime repete o mesmo valor a cada frame
            //Incrementar o valor de timer com o fixedDeltaTime
            timer += Time.fixedDeltaTime;
            //Se "timer" for maior que o valor de "dashDelay"
            if (timer >= dashDelay)
            {
                //Atribuir true para o bool "dashEnabled", permitindo a utilização de um segundo dash
                dashEnabled = true;
            }

            yield return null;
        }       
        //Se o valor de "timer" for maior ou igual o valor de "dashCooldown"...
        if(timer >= dashCooldown)//aqui apos rodar o while 10 segundos, ira rodar mais 10 segundos para o valor do dashes voltar a ser 2 
        {
            //Atribuir ao contador de dashes a quantidade máxima de dash daquele peixe
            dashes = maxDashes;
        }     

        Debug.Log("Dashes: " + dashes);
        Debug.Log("Dash is enabled: " + dashEnabled);   
    }
   
}
