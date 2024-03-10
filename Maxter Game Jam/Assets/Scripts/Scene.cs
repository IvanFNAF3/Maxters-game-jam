using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void ChangeScenes(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
