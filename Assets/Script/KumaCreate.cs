﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumaCreate : MonoBehaviour
{
    GameObject kuma;
    Vector2 kumaPosition = new Vector2(6.0f, -5.0f);

    //8秒ごとのクマ生成処理用
    float timeElapsed;
    bool leftRight = true; //trueは右


    void Start()
    {
        kuma = (GameObject)Resources.Load("kuma");

        //左右に5体のくまを生成
        for (int i = 0; i < 2; i++)
        {
            //1週目は右側に下方から作成（x軸少しずつずらし、ばらけるように）
            while (kumaPosition.y < 6)
            {
                Instantiate(kuma, kumaPosition, Quaternion.identity);
                kumaPosition.x = kumaPosition.x - 0.2f;
                kumaPosition.y = kumaPosition.y + 2.5f;
            }

            //2週目は左側に下方から作成
            kumaPosition = new Vector2(-6.0f, -5.0f);
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

            //左右順番に生成
            if (leftRight) { kumaPosition = new Vector2(5.0f, yPosition); }
            else { kumaPosition = new Vector2(-5.0f, yPosition); }

            //くま生成
            Debug.Log("newくまcreate" + yPosition);
            Instantiate(kuma, kumaPosition, Quaternion.identity);

            timeElapsed = 0.0f; //再カウント
            leftRight = !leftRight; //左右変更
        }
    }
}
