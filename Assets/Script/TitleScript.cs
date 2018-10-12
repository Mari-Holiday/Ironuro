using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleScript : MonoBehaviour
{
    /* タイトルや見出しを揺らすスクリプト */

    Quaternion rotateNormal;

    //カウント用
    float timeElapsed;

    void Start()
    {
        //通常の回転方向を保持
        rotateNormal = gameObject.GetComponent<Transform>().rotation;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 2.0f)
        {
            //1秒間ランダムに弱めで揺らす
            gameObject.transform.DOShakeRotation(1f, 15, 5, 10);
            gameObject.transform.rotation = rotateNormal;

            timeElapsed = 0.0f;
        }
    }
}
