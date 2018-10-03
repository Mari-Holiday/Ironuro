using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class KumaScript : MonoBehaviour
{
    //アタッチのGameObjectから取得
    SpriteRenderer kumaSprite;
    TapGesture tapGesture;

    //変更対象のSpriteを保持するGameObjectを取得
    GameObject changeSprite;



    void Start()
    {
        kumaSprite = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(kumaSprite.color);
        tapGesture = gameObject.GetComponent<TapGesture>();
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    private void OnTapped(object sender,EventArgs e){
        Debug.Log("");
    }
}
