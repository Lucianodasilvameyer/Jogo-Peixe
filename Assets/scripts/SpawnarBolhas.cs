using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarBolhas : MonoBehaviour
{
    

    

    [SerializeField]
    private int distanciaBolhaPeixe;

    public GameObject bolhasPrefab;

    [SerializeField]
    public Transform bolhas;

    [SerializeField]
    public Transform Peixe;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void SpawnarBolha()
    {
       
       /* Vector2 inipos = bolhas.transform.position;

        Vector2 position_ = inipos;

        Vector2 inipos2 = Peixe.transform.position;

        Vector2 position2_ = inipos2;

        Vector2 position = position2_ - position_;

        position.x += distanciaBolhaPeixe;


        



        GameObject go = Instantiate(bolhasPrefab, position, Quaternion.identity);*/ 

    }
   

    
}
