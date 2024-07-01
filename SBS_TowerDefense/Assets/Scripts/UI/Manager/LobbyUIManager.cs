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
        // 마우스 좌클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            showDifficultyUI();
        }
        // 마우스 우클릭 감지
        else if (Input.GetMouseButtonDown(1))
        {
            showDifficultyUI();
        }
        // 아무 키보드 입력 감지
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
