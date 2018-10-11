using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelButtonScript : MonoBehaviour
{
    //レベル選択ボタンにアタッチ

    [SerializeField] //対応するアニメーションくまオブジェクトをインスペクターから格納
    private GameObject levelKuma;

    void Start()
    {

    }

    void Update()
    {

    }

    public void levelKumaApper() //レベル選択後にアニメーション再生用
    {
        levelKuma.SetActive(true);
        levelKuma.transform.DOPunchScale(new Vector3(0.5f, 0.5f), 1.0f, 5, 0.5f);
    }

    public void levelKumaDisapper() //実機では使用なし
    {
        levelKuma.SetActive(false);
    }
}
