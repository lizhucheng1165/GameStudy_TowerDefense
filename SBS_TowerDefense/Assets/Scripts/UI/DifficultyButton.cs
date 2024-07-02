using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public void OnClicked(int difficulty)
    {
        GameInstance.Instance.difficulty = difficulty;
        SceneManager.LoadScene("Game");
    }
}
