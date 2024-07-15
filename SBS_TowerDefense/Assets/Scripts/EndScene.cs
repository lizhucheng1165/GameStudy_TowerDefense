using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;

    private void Start()
    {
        if (GameManager.playerWon)
        {
            winText.gameObject.SetActive(true);
            loseText.gameObject.SetActive(false);
        }
        else
        {
            loseText.gameObject.SetActive(true);
            winText.gameObject.SetActive(false);
        }
    }
}
