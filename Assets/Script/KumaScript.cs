using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class KumaScript : MonoBehaviour
{
    //アタッチのGameObjectから取得
    SpriteRenderer kumaSprite;

    //public TapGesture tapGesture;

    //変更対象のSpriteを保持するGameObject(取得予定)
    public SpriteRenderer changeSprite;


    void Start()
    {
        kumaSprite = gameObject.GetComponent<SpriteRenderer>();
        //Debug.Log(kumaSprite.color);
    }

    void Update()
    {
        //実機用
        if(Input.touchCount > 0){
            Debug.Log("inputtouchsareta");
        }

        //検証用
        if(Input.GetMouseButtonDown(0)){

            
            //changeSprite.color = kumaSprite.color;
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
