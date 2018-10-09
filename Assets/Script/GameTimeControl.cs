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
    bool finishImageDo = false;
    public GameObject otsukareImage;
    bool otsukareImageDo = false;

    public float gamePlayTime;

    bool gameStart = false;

    public GameObject kumaCreate;
    public GameObject kumaIntroduce;
    public GameObject kumaFinish;

    //100点になった場合
    public static bool fullGame = false;
    float fullGameTime;

    void Start()
    {
        kumaIntroduce.SetActive(true);
        timeElapsed = 0.0f;
        fullGame = false;
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


        if (fullGame)
        {
            if (gameStart)
            {
                fullGameTime = timeElapsed;
                Debug.Log(fullGameTime);
                Debug.Log(timeElapsed);

                if (!finishImageDo)
                {
                    finishImage.transform.DOMove(new Vector2(0.0f, 0.0f), 2f);
                    finishImageDo = true;
                    gameStart = false;
                    KumaScript.gameStart = false;
                }
            }

            if (timeElapsed > fullGameTime + 4)
            {
                kumaCreate.SetActive(false);
                kumaFinish.SetActive(true);
            }

        }
        else //100点以下の場合
        {

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
                if (!finishImageDo)
                {
                    finishImage.transform.DOMove(new Vector2(0.0f, 0.0f), 2f);
                    finishImageDo = true;
                    KumaScript.gameStart = false;
                }
            }

            if (timeElapsed > (gamePlayTime + 11.0f) + 2)//おつかれくまを登場させる
            {
                if (!otsukareImageDo)
                {
                    otsukareImage.transform.DOMove(new Vector2(-0.7f, -0.7f), 2f).SetEase(Ease.OutBounce);
                    otsukareImageDo = true;
                }
            }

            if (timeElapsed > (gamePlayTime + 11.0f) + 6) //終了
            {
                if (gameStart)
                {
                    kumaCreate.SetActive(false);
                    gameStart = false;
                    kumaFinish.SetActive(true);
                }
            }

        }

    }
}


