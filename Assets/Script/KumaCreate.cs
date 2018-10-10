using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumaCreate : MonoBehaviour
{
    GameObject kumaPrefab;
    Vector2 kumaPosition = new Vector2(6.0f, -5.0f);

    //8秒ごとのクマ生成処理用
    float timeElapsed;
    bool leftRight = true; //trueは右

    //色順番&ランダムに排出用
    static int colorNumCount = 0;
    public static int startColorNumCount = 0; //0~白黒あり、2~白黒なし 

    public static int oneColorNum = 0; //レベル1の際の単色

    GameObject[] kumaObjects;


    void Start()
    {
        //ループ用初期値設定
        colorNumCount = startColorNumCount;

        kumaPrefab = (GameObject)Resources.Load("kuma");
        int choseColorNum = startColorNumCount;

        //左右に5体のくまを生成
        for (int i = 0; i < 2; i++)
        {
            //1週目は右側に下方から作成（x軸少しずつずらし、ばらけるように）
            while (kumaPosition.y < 6)
            {
                if (choseColorNum >= 6) //6以上は色設定ないため作成させない
                {
                    break;
                }

                GameObject kuma = Instantiate(kumaPrefab, kumaPosition, Quaternion.identity);

                GameObject kumaPen = kuma.transform.Find("kumapen").gameObject;
                SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();

                if (LevelScript.choisedLevel == level.lower) //単色の場合
                {
                    kumaPenSprite.color = KumaColor.Instance.chosePenColor(oneColorNum);
                }
                else //カラフルの場合
                {
                    kumaPenSprite.color = KumaColor.Instance.chosePenColor(choseColorNum);
                    choseColorNum++;
                }

                kumaPosition.x = kumaPosition.x - 0.2f;
                kumaPosition.y = kumaPosition.y + 2.5f;
            }

            //2週目は左側に下方から作成
            kumaPosition = new Vector2(-6.0f, -5.0f);

            //全色くまを作成するために+1で再設定（2週目用）
            choseColorNum = startColorNumCount + 1;
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 5.0f)
        {
            if (kumaCheck()) //30匹以上いる場合は生成しない
            {

                //現れる場所をランダムに（毎回違うゲームになるように）
                System.Random yRandom = new System.Random();
                float yPosition = (float)yRandom.Next(-5, 5);

                int choseColorNum = colorNumCount;


                //左右順番に生成
                if (leftRight) { kumaPosition = new Vector2(5.0f, yPosition); }
                else { kumaPosition = new Vector2(-5.0f, yPosition); }

                //くま生成
                Debug.Log("newくまcreate" + yPosition);
                GameObject kuma = Instantiate(kumaPrefab, kumaPosition, Quaternion.identity);

                if (LevelScript.choisedLevel == level.lower) //単色の場合
                {
                    //くま色設定
                    GameObject kumaPen = kuma.transform.Find("kumapen").gameObject;
                    SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
                    kumaPenSprite.color = KumaColor.Instance.chosePenColor(oneColorNum);
                }
                else //カラフルの場合
                {
                    //ランダム時（6,7の場合）の色決定
                    if (colorNumCount >= 6)
                    {
                        choseColorNum = yRandom.Next(startColorNumCount, 5);
                        Debug.Log("ランダム値→" + choseColorNum);
                    }

                    //くま色設定
                    GameObject kumaPen = kuma.transform.Find("kumapen").gameObject;
                    SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
                    kumaPenSprite.color = KumaColor.Instance.chosePenColor(choseColorNum);

                    //0〜5までは各色を、6,7はランダム色、をループ（8週目は初期値に戻す）
                    colorNumCount++;
                    if (colorNumCount >= 8) { colorNumCount = startColorNumCount; }
                }

                leftRight = !leftRight; //左右変更

            }

            timeElapsed = 0.0f; //再カウント

        }
    }

    bool kumaCheck()
    {
        kumaObjects = GameObject.FindGameObjectsWithTag("kuma");
        Debug.Log("くまの量" + kumaObjects.Length);
        if (kumaObjects.Length >= 30)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}
