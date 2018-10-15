using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using TouchScript.Gestures; //今回はタッチスクリプト導入なし

public class KumaScript : MonoBehaviour
{

    /* くまオブジェクトにアタッチ、鉛筆などの保持
    　　また、自爆を制御  */

    GameObject kuma;
    GameObject kumaPen;
    SpriteRenderer kumaPenSprite;
    GameObject kumaFace;

    //自爆8秒カウント用
    float timeElapsed;

    //ゲーム終了後（結果画面前）制御用、全くま共通
    public static bool gameStart;


    void Start()
    {
        kuma = gameObject;

        //くまの子要素となるクマペンとくま顔を取得、保持
        kumaPen = kuma.transform.Find("kumapen").gameObject;
        kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
        kumaFace = kuma.transform.Find("kumaTouched").gameObject;
    }

    void Update()
    {
        if (gameStart) //ゲーム中
        {
            timeElapsed += Time.deltaTime; //カウント開始

            //画面内or外の確認
            if (kuma.transform.position.x > -4 && kuma.transform.position.x < 4)
            {
                timeElapsed = 0.0f; //画面内ならカウントしない
            }
            else
            {
                if (timeElapsed > 8.0f)　//画面外ならカウント
                {
                    //カウント8秒になったらオブジェクト削除
                    Debug.Log("くまDestroy");
                    Destroy(kuma);
                }
            }

        }
        else //ゲーム終了後は全くま削除
        {
            Destroy(kuma);
        }

    }

    public void changeFaceTouched()
    {
        kumaFace.SetActive(true);
        Debug.Log("yobareta");
    }

    public void changeFaceNotTouched()
    {
        kumaFace.SetActive(false);
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
