using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClass : MonoBehaviour
{
    //塗られる対象（ohanaの花びらとか）の情報を格納するクラス
    //ゲームが始まる時にScoreScriptから格納され、コントロールされる
    //なので情報の保持が第一業務

    //主役の色の入るオブジェクト
    public GameObject nowPoint;
    //現在の色
    public kumaCOL nowColor;

    //正解の色が入っているオブジェクト
    public GameObject collectPoint;
    //正解の色
    public kumaCOL collectColor;

    //正しい色が入っているか
    bool sameColor = false;


    void Update()
    {
        //正解か不正解か常に確認、プロパティに保持
        if (nowColor == collectColor)
        {
            sameColor = true;
        }
        else
        {
            sameColor = false;
        }

    }
}
