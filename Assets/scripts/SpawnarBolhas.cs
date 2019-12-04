using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarBolhas : MonoBehaviour
{
    public int subidaDasBolhas;

    public GameObject bolhasPrefab;

    [SerializeField]
    private Transform bolhas; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inipos = bolhas.transform.position;
        Vector2 position = inipos;
        position.y = subidaDasBolhas;


        spawnrBolha(position);

    }
    public void spawnrBolha(Vector2 position)
    {
        GameObject Go = Instantiate(bolhasPrefab, position, Quaternion.identity) 
    }
}
