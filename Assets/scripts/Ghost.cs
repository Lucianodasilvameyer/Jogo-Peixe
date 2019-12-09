using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform Player_;

    public int distanciaDoGhost;

    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;

    private float spawnFantasmaInicial1;
    [SerializeField]
    private float spawnFantasmaFinal1;

    private float spawnFantasmaInicial2;
    [SerializeField]
    private float spawnFantasmaFinal2;

    private float spawnFantasmaInicial3;
    [SerializeField]
    private float spawnFantasmaFinal3;

    private float spawnFantasmaInicial4;
    [SerializeField]
    private float spawnFantasmaFinal4;

    public int carregar = 0;


    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds = ghostDelay;  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inipos = Player_.transform.position;
        Vector2 Position = inipos;
        Position.x -= distanciaDoGhost;
        Position.y -= distanciaDoGhost;


       if (ghostDelaySeconds > 0)
       {
            ghostDelaySeconds -= Time.deltaTime;
       }
       else
       {
            ghostDelaySeconds = ghostDelay;
       }
       if(Time.time>=spawnFantasmaInicial1+spawnFantasmaFinal1 && carregar==0 && Input.GetKey(KeyCode.Space))
       {
            spawnFantasmaInicial1 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
       }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {
            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {
            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {
            spawnFantasmaInicial4 = Time.time;
            carregar = 0;
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
       }


    }
}
