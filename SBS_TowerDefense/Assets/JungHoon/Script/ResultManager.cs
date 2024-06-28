using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button btnBackToLobby;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendBackToLobbyScene()
    {
        SceneManager.LoadScene("Junghoon/Scene/PJH_Scene_Lobby");
    }
}
