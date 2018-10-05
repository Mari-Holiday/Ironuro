using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class KumaScript : MonoBehaviour
{
    GameObject kuma;

    GameObject kumaPen;
    SpriteRenderer kumaPenSprite;

    //5秒カウント用
    float timeElapsed;

    //ゲーム終了後削除用
    public static bool gameStart;


    void Start()
    {
        kuma = gameObject;

        //くまの子要素となるクマペンを取得
        kumaPen = kuma.transform.Find("kumapen").gameObject;
        kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();

        //kumaPenSprite.color = ColorClass.chosePenColor(3);
    }

    void Update()
    {
        if (gameStart)
        {
            timeElapsed += Time.deltaTime;

            //画面内外の確認
            if (kuma.transform.position.x > -4 && kuma.transform.position.x < 4)
            {
                //画面内なら再カウント
                timeElapsed = 0.0f;
            }
            else
            {
                //画面外ならカウント
                //カウント8秒になったらオブジェクト削除
                if (timeElapsed > 8.0f)
                {
                    Debug.Log("くまDestroy");
                    Destroy(kuma);
                }
            }

        }
        else //ゲーム終了後は削除
        {
            Debug.Log("ゲーム終了、全くまDestroy");
            Destroy(kuma);
        }

    }



    //＝＝＝＝＝実機タップジェスチャー用
    // private void OnEnable()
    // {
    //     tapGesture.Tapped += OnTapped;
    // }

    // private void OnDisable()
    // {
    //     tapGesture.Tapped -= OnTapped;
    // }

    // private void OnTapped(object sender,EventArgs e){
    //     Debug.Log("touchsareta");
    //     changeSprite.color = kumaSprite.color;
    // }
}
