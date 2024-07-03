using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public int nMyWaveNumber;
    public int nCreateEnemyCount;
    public float fWaveStartDelaySecond;

    // Start is called before the first frame update
    void Start()
    {
        nMyWaveNumber = 0;
        nCreateEnemyCount = 0;
        fWaveStartDelaySecond = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
