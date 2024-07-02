using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    Canvas canvas;
    GameObject titlePanel;
    GameObject difficultyPanel;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        titlePanel = Resources.Load<GameObject>("Prefabs/UI/Lobby/Panel_Title");
        difficultyPanel = Resources.Load<GameObject>("Prefabs/UI/Lobby/Panel_Difficulty");
    }
    // Start is called before the first frame update
    void Start()
    {
        titlePanel = Instantiate(titlePanel, Vector3.zero, Quaternion.identity);
        titlePanel.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showDifficultyUI()
    {
        Destroy(titlePanel);
        difficultyPanel = Instantiate(difficultyPanel, Vector3.zero, Quaternion.identity);
        difficultyPanel.transform.SetParent(canvas.transform, false);
    }
}
