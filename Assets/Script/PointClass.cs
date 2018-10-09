using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClass : MonoBehaviour
{
    //塗られる対象（ohanaの花びらとか）の情報を格納するクラス
    //ゲームが始まる時にScoreScriptから格納され、コントロールされる

    //ゲーム色ぬり上の色の入るオブジェクトにアタッチする

    public Color nowColor; //現在の色

    public GameObject collectPointParent; //正解のオブジェクトを束ねている親オブジェクト
    GameObject collectPoint; //正解の色が入っているオブジェクト
    [SerializeField]
    Color collectColor; //正解の色

    public int myNum; //問題番号（オブジェクトの順番）

    private bool sameColor = false; //正しい色が入っているか


    void Start()
    {
        nowColor = gameObject.GetComponent<SpriteRenderer>().color;

        collectPoint = collectPointParent.transform.Find(gameObject.name).gameObject;
        collectColor = collectPoint.GetComponent<SpriteRenderer>().color;

        ScoreScript.questionKindList[myNum] = this;
    }


    void Update()
    {
        //正解か不正解か常に確認、プロパティに保持
        if (nowColor == collectColor && !sameColor)
        {
            sameColor = true;
            Debug.Log("yes! same color!");
        }

        if (nowColor != collectColor && sameColor)
        {
            sameColor = false;
        }

    }

    public bool getSameColor()
    {
        return sameColor;
    }
}
