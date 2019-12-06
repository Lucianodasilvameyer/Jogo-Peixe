using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float GhostDelay;
    private float GhostDelaySeconds;

    // Start is called before the first frame update
    void Start()
    {
        GhostDelaySeconds = GhostDelay; 
    }

    // Update is called once per frame
    void Update()
    {
        if (GhostDelaySeconds > 0)
        {
            GhostDelaySeconds -= Time.deltaTime;
        }
        else
        {
            GhostDelaySeconds = GhostDelay;
        }
    }
}
