using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarBolhas : MonoBehaviour
{
    [SerializeField]
    private int subidaDasBolhas;

    [SerializeField]
    private int distanciaBolhaPeixe;

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

        



    }
    public void SpawnarBolha()
    {
        Vector2 iniposBolhas = bolhas.transform.position;
        Vector2 position = iniposBolhas;
        position.x -= distanciaBolhaPeixe;
        position.y += subidaDasBolhas;

        GameObject go = Instantiate(bolhasPrefab, position, Quaternion.identity);

    }
}
