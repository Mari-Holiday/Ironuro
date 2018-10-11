using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameTimeControl : MonoBehaviour
{
    /* IronuroGame内のレベル選択→おてほん確認→ゲーム→答え合わせ
        の順番、時間などの制御 */

    //レベル選択後、時間カウント開始、経過時間を格納
    float timeElapsed;

    //画面上のカウントや時間経過によるアニメーション制御用
    public Text introduceTimeText;
    public GameObject hazimaruyoImage;
    public Text gameTimeText;
    public GameObject finishImage;
    bool finishImageDo = false;
    public GameObject otsukareImage;
    bool otsukareImageDo = false;

    //ゲーム制限時間をインスペクターから格納
    public float gamePlayTime;

    //ゲーム中true、状況の共有用
    bool gameStart = false;

    //各スクリーンのオブジェクトをインスペクターから格納
    public GameObject kumaCreate;
    public GameObject kumaIntroduce;
    public GameObject kumaFinish;
    public GameObject kumaLevel;

    //100点になった場合の制御用
    public static bool fullGame = false;
    float fullGameTime;

    //レベル選択画面の制御用
    public static bool levelChoise = true;


    void Start()
    {
        //レベル選択画面以外を非表示に
        kumaLevel.SetActive(true);
        kumaIntroduce.SetActive(false);
        kumaCreate.SetActive(false);
        kumaFinish.SetActive(false);

        //シーン遷移後も初期化
        timeElapsed = 0.0f;
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
            timeElapsed += Time.deltaTime; //カウント開始

            if (timeElapsed < 11.0f) //1〜10秒は見本表示導入画面の表示
            {
                kumaLevel.SetActive(false);
                kumaIntroduce.SetActive(true);
                int countdownStart = (int)(11.0f - timeElapsed);
                if (countdownStart == 0) { hazimaruyoImage.SetActive(true); }
                introduceTimeText.text = countdownStart.ToString();
            }


            if (fullGame) //全色ぬりを完成させた場合（そのため1週目は通らない）
            {
                if (gameStart)
                {
                    fullGameTime = timeElapsed;

                    if (!finishImageDo) //ゲーム終了処理
                    {
                        finishImage.transform.DOMove(new Vector2(0.0f, 0.0f), 2f);
                        finishImageDo = true;
                        gameStart = false;
                        KumaScript.gameStart = false;
                    }
                }

                if (timeElapsed > fullGameTime + 4) //4秒間ゲーム終了画面の表示、その後結果画面へ遷移
                {
                    kumaCreate.SetActive(false);
                    kumaFinish.SetActive(true);
                }

            }
            else //ゲームプレイ中、100点以下の場合
            {

                if (timeElapsed > 11.0f && timeElapsed < (gamePlayTime + 11.0f)) //11秒〜ゲーム・くま作成開始
                {

                    if (!gameStart)
                    {
                        kumaIntroduce.SetActive(false);
                        kumaCreate.SetActive(true);
                        gameStart = true;
                        KumaScript.gameStart = true;
                    }

                    int countdownStart = (int)((gamePlayTime + 11.0f) - timeElapsed); //残り秒数の画面表示
                    gameTimeText.text = countdownStart.ToString();
                }

                if (timeElapsed > (gamePlayTime + 11.0f)) //ゲーム終了
                {
                    if (!finishImageDo) //ゲーム終了処理
                    {
                        finishImage.transform.DOMove(new Vector2(0.0f, 0.0f), 2f);
                        finishImageDo = true;
                        KumaScript.gameStart = false;
                    }
                }

                if (timeElapsed > (gamePlayTime + 11.0f) + 2) //ゲーム終了画面から2秒後、おつかれくまを登場させる
                {
                    if (!otsukareImageDo)
                    {
                        otsukareImage.transform.DOMove(new Vector2(-0.7f, -0.7f), 2f).SetEase(Ease.OutBounce);
                        otsukareImageDo = true;
                    }
                }

                if (timeElapsed > (gamePlayTime + 11.0f) + 6) //さらに4秒後、ゲーム結果画面へ遷移
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


