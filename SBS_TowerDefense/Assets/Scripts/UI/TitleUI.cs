using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    LobbyUIManager lobbyUIManager;
    // Start is called before the first frame update
    void Start()
    {
        lobbyUIManager = GameObject.Find("LobbyUIManager").GetComponent<LobbyUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            lobbyUIManager.showDifficultyUI();
        }
        // 마우스 우클릭 감지
        else if (Input.GetMouseButtonDown(1))
        {
            lobbyUIManager.showDifficultyUI();
        }
        // 아무 키보드 입력 감지
        if (Input.anyKeyDown)
        {
            lobbyUIManager.showDifficultyUI();
        }
    }
}
