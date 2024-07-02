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
        // ���콺 ��Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            lobbyUIManager.showDifficultyUI();
        }
        // ���콺 ��Ŭ�� ����
        else if (Input.GetMouseButtonDown(1))
        {
            lobbyUIManager.showDifficultyUI();
        }
        // �ƹ� Ű���� �Է� ����
        if (Input.anyKeyDown)
        {
            lobbyUIManager.showDifficultyUI();
        }
    }
}
