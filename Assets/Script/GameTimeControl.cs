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
    public GameObject otsukareImage;

    public float gamePlayTime;

    bool gameStart = false;

    public GameObject kumaCreate;
    public GameObject kumaIntroduce;
    public GameObject kumaFinish;

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

        if (timeElapsed > 11.0f && timeElapsed < (gamePlayTime + 11.0f)) //10秒すぎたらゲーム・くま作成開始
        {

            if (!gameStart)
            {
                kumaIntroduce.SetActive(false);
                kumaCreate.SetActive(true);
                gameStart = true;
                KumaScript.gameStart = true;
            }

            int countdownStart = (int)((gamePlayTime + 11.0f) - timeElapsed);
            gameTimeText.text = countdownStart.ToString();
        }

        if (timeElapsed > (gamePlayTime + 11.0f)) //ゲーム終了
        {
            finishImage.transform.DOMove(new Vector2(0.0f, 0.0f), 2f);
        }

        if (timeElapsed > (gamePlayTime + 11.0f) + 2)//おつかれくまを登場させる
        {
            otsukareImage.transform.DOMove(new Vector2(-0.7f, -0.7f), 2f);
            //☆のちほど、イージング追加予定
        }

        if (timeElapsed > (gamePlayTime + 11.0f) + 10) //終了
        {
            if (gameStart)
            {
                kumaCreate.SetActive(false);
                gameStart = false;
                KumaScript.gameStart = false;

                kumaFinish.SetActive(true);
            }
        }
    }

}
