using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : Singleton<SceneLoder>
{

    public void MoveToNextScene()
    {
        SceneManager.LoadScene(1); //To Main
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    public void MoveToResultScene(GameState result)
    {
        if (result == GameState.GAME_WON)
        {
            SceneManager.LoadScene(2); //To Win
        }
        else
        {
            SceneManager.LoadScene(3); //To Lose
        }
    }
}
