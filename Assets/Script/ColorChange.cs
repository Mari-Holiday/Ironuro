using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //アタッチのGameObjectから取得
    SpriteRenderer kumaSprite;

    //変更対象のSpriteを保持するGameObjectを取得
    GameObject changeSprite;

    void Start()
    {
        kumaSprite = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(kumaSprite.color);
    }

    void Update()
    {
        
    }
}
