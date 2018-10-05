using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameTimeControl : MonoBehaviour
{
    float timeElapsed;
    public Text introduceTimeText;
    public GameObject hazimaruyoImage;
    public Text gameTimeText;
    public GameObject finishImage;

    bool gameStart = false;

    public GameObject kumaCreate;
    public GameObject kumaIntroduce;

    void Start()
    {
        kumaIntroduce.SetActive(true);
        timeElapsed = 0.0f;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed < 11.0f)
        {
            int countdownStart = (int)(11.0f - timeElapsed);
            if (countdownStart == 0) { hazimaruyoImage.SetActive(true); }
            introduceTimeText.text = countdownStart.ToString();
        }

        if (timeElapsed > 11.0f && timeElapsed < 111.0f) //10秒すぎたらゲーム・くま作成開始
        {
            if (!gameStart)
            {
                kumaIntroduce.SetActive(false);
                kumaCreate.SetActive(true);
                gameStart = true;
                KumaScript.gameStart = true;
            }

            int countdownStart = (int)(111.0 - timeElapsed);
            gameTimeText.text = countdownStart.ToString();
        }

        if(timeElapsed > 111.0f) //ゲームスタート後100秒すぎたらゲーム終了
        {
            finishImage.transform.DOMove(new Vector2(0.0f,0.0f),2f);
        }

        if (timeElapsed > 115.0f) //ゲームスタート後100秒すぎたらゲーム終了
        {
            if (gameStart)
            {
                kumaCreate.SetActive(false);
                gameStart = false;
                KumaScript.gameStart = false;
            }
        }
    }

}
