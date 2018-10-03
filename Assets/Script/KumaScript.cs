using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class KumaScript : MonoBehaviour
{
    GameObject kuma;
    
    //5秒カウント用
    float timeElapsed;


    void Start()
    {
        kuma = gameObject;
    }

    void Update()
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
