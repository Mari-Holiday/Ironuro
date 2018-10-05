using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreScript : MonoBehaviour
{
    //下記4コレクションに色塗られる対象オブジェクトと、オブジェクトの現在の色を格納
    //いや、それならカラーのクラス作って、それを1コレクションで管理しよう！！！！

    private static List<GameObject> questionPoints = new List<GameObject>();
    private static List<GameObject> answerPoints = new List<GameObject>();

    public static List<kumaCOL> questions = new List<kumaCOL>();
    public static List<kumaCOL> answers = new List<kumaCOL>();

    void Start()
    {

    }

    void Update()
    {

    }
}
