using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : Singleton<GameInstance>
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Instance);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
