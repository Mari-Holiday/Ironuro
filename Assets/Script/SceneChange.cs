using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /* シーン遷移させるボタンなどにアタッチ、イベント等でメソッド呼び出し */

    //遷移先のシーンを文字列でインスペクターから格納
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
