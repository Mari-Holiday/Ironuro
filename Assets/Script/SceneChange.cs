using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    void Start()
    {

    }

    void Update()
    {

    }

    public void sceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
