using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlashingScript : MonoBehaviour
{
    /* オブジェクトを点滅させる */

    //Alfaで制御するため、点滅対象にはCanvasGroupをアタッチ
    CanvasGroup flashCanvasGroup;
    public Ease easeType;　//イージングタイプはインスペクターで選択

    void Start()
    {
        //Alfaの上下をループさせて点滅
        flashCanvasGroup = gameObject.GetComponent<CanvasGroup>();
        flashCanvasGroup.DOFade(0.7f, 0.5f).SetEase(easeType).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {

    }
}
