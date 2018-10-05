using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlashingScript : MonoBehaviour
{
    CanvasGroup flashCanvasGroup;
    public Ease easeType;

    void Start()
    {
        flashCanvasGroup = gameObject.GetComponent<CanvasGroup>();
        flashCanvasGroup.DOFade(0.7f, 0.5f).SetEase(easeType).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {

    }
}
