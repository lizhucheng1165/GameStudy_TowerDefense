using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ��Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            showDifficultyUI();
        }
        // ���콺 ��Ŭ�� ����
        else if (Input.GetMouseButtonDown(1))
        {
            showDifficultyUI();
        }
        // �ƹ� Ű���� �Է� ����
        if (Input.anyKeyDown)
        {
            showDifficultyUI();
        }
    }

    public void showDifficultyUI()
    {
        GameObject titlePanel = GameObject.Find("Panel_Title");

        if (titlePanel != null)
        {
            titlePanel.SetActive(false);
        }
    }
}
