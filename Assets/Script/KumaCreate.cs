﻿using System.Collections;
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
    static int colorNumCount;


    void Start()
    {
        kumaPrefab = (GameObject)Resources.Load("kuma");
        int choseColorNum = 0;

        //左右に5体のくまを生成
        for (int i = 0; i < 2; i++)
        {
            //1週目は右側に下方から作成（x軸少しずつずらし、ばらけるように）
            while (kumaPosition.y < 6)
            {
                GameObject kuma = Instantiate(kumaPrefab, kumaPosition, Quaternion.identity);

                GameObject kumaPen = kuma.transform.FindChild("kumapen").gameObject;
                SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();

                kumaPenSprite.color = ColorClass.chosePenColor(choseColorNum);
                choseColorNum++;

                kumaPosition.x = kumaPosition.x - 0.2f;
                kumaPosition.y = kumaPosition.y + 2.5f;
            }

            //2週目は左側に下方から作成
            kumaPosition = new Vector2(-6.0f, -5.0f);

            //全色くまを作成するために1からに再設定
            choseColorNum = 1;
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 5.0f)
        {
            //現れる場所をランダムに（毎回違うゲームになるように）
            System.Random yRandom = new System.Random();
            float yPosition = (float)yRandom.Next(-5, 5);

            int choseColorNum = colorNumCount;
            //ランダム時（6,7の場合）の色決定
            if (colorNumCount >= 6)
            {
                choseColorNum = yRandom.Next(0, 5);
                Debug.Log("ランダム値→" + choseColorNum);
            }

            //左右順番に生成
            if (leftRight) { kumaPosition = new Vector2(5.0f, yPosition); }
            else { kumaPosition = new Vector2(-5.0f, yPosition); }

            //くま生成
            Debug.Log("newくまcreate" + yPosition);
            GameObject kuma = Instantiate(kumaPrefab, kumaPosition, Quaternion.identity);

            //くま色設定
            GameObject kumaPen = kuma.transform.FindChild("kumapen").gameObject;
            SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
            kumaPenSprite.color = ColorClass.chosePenColor(choseColorNum);

            //0〜5までは各色を、6,7はランダム色、をループ
            colorNumCount++;
            if (colorNumCount >= 8) { colorNumCount = 0; }

            timeElapsed = 0.0f; //再カウント
            leftRight = !leftRight; //左右変更
        }
    }
}