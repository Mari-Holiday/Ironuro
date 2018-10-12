using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClass : MonoBehaviour
{
    /* 色ぬられる対象（ohanaの花びらなど）にアタッチし、情報を格納するクラス */
    //ゲーム開始以降ScoreScriptから制御される

    [HideInInspector]
    public Color nowColor; //現在の色

    public GameObject collectPointParent; //正解のオブジェクトを束ねている親オブジェクト
    GameObject collectPoint; //正解の色が入っているオブジェクト

    [HideInInspector]
    public Color collectColor; //正解の色

    [SerializeField]
    private int myNum; //問題番号（オブジェクトの順番）をインスペクターから格納

    private bool sameColor = false; //正しい色が入っているか


    void Start()
    {
        //現在の色を取得、格納（ただし現在はゲーム開始時は必ず白）
        nowColor = gameObject.GetComponent<SpriteRenderer>().color;

        //問題と同名である正解の色を保持したオブジェクトを検索、保持
        collectPoint = collectPointParent.transform.Find(gameObject.name).gameObject;
        collectColor = collectPoint.GetComponent<SpriteRenderer>().color;

        //問題を制御しているScoreScriptの該当問題番号に自身を格納
        ScoreScript.questionKindList[myNum] = this;
    }


    void Update()
    {
        //正解か不正解か常に確認、プロパティに保持
        if (nowColor == collectColor && !sameColor) { sameColor = true; }
        if (nowColor != collectColor && sameColor) { sameColor = false; }

    }

    public bool getSameColor()　//現在の正解状況を返すメソッド
    {
        return sameColor;
    }

}
