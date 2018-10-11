using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    /* スコア（正誤率）管理用　*/

    //問題色ぬられるオブジェクト用
    public int questionsNum; //インスペクターから格納
    public static PointClass[] questionKindList;

    //正解中の色ぬり数
    private int collectsNum = 0;

    //正答率
    private float collectAnswerRate;
    public Text collectAnswerRateText; //画面表示用Textをインスペクターから格納

    void Awake()
    {
        //問題番号と同じ番号に格納するため＋1（0が存在するため）
        questionKindList = new PointClass[questionsNum + 1];
    }

    void Start()
    {

    }

    void Update()
    {
        //現在の状況を確認
        int nowCollectsNum = 0;
        for (int i = 1; i < questionKindList.Length; i++) //正解中の問題をチェック
        {
            PointClass point = questionKindList[i];

            if (point.getSameColor())
            {
                nowCollectsNum++;
            }
        }

        //現在の状況をフィールドに保持
        collectsNum = nowCollectsNum;

        collectAnswerRate = ((float)collectsNum / (float)questionsNum) * 100;
        collectAnswerRateText.text = Mathf.Floor(collectAnswerRate).ToString();
        AnswerScript.collectAnswerRate = collectAnswerRateText.text;

        if (collectsNum == questionsNum)
        {
            GameTimeControl.fullGame = true;
        }
    }
}
