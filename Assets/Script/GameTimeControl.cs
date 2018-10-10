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
    public GameObject kumaLevel;

    //100点になった場合
    public static bool fullGame = false;
    float fullGameTime;

    //レベル選択画面の制御
    public static bool levelChoise = true;


    void Start()
    {
        Debug.Log("新ゲームはじまるよ");

        kumaLevel.SetActive(true);
        kumaIntroduce.SetActive(false);
        kumaCreate.SetActive(false);
        kumaFinish.SetActive(false);

        timeElapsed = 0.0f;

        //シーン遷移後も初期化
        fullGame = false;
        levelChoise = true;
    }

    void Update()
    {
        if (levelChoise) //レベル選択に時間制限は無し
        {

        }
        else
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed < 11.0f)
            {
                kumaLevel.SetActive(false);
                kumaIntroduce.SetActive(true);
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
}


