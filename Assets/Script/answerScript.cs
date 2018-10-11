using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerScript : MonoBehaviour
{
    /* 問題と答えを格納し、こたえあわせ画面にクローンを作成 */

    //問題と答えのそれぞれohana親オブジェクトをインスペクターから格納
    public GameObject ohanaAnswer;
    public GameObject ohanaPlayed;

    //ScoreScriptから正解率を受け取り、こたえあわせ画面に表示
    public static string collectAnswerRate;
    public Text collectAnswerRateText; //こたえあわせ画面の該当Textをインスペクターから格納

    //すばらしいスタンプのキャンバスグループを格納（Alfaを変更するため）
    public CanvasGroup subarashiCanvasGroup;

    void Start()
    {
        //おてほんとゲーム結果のオブジェクトのクローンを作成
        GameObject answerClone = GameObject.Instantiate(ohanaAnswer);
        GameObject playedClone = GameObject.Instantiate(ohanaPlayed);

        //おてほんの場所と大きさを指定
        answerClone.transform.position = new Vector2(-2.25f, 0.55f);
        answerClone.transform.localScale = new Vector2(0.5f, 0.5f);

        //ゲーム結果の場所と大きさを指定
        playedClone.transform.position = new Vector2(-0.06f, -0.29f);
        playedClone.transform.localScale = new Vector2(1.0f, 1.0f);

        //正解率の表示
        collectAnswerRateText.text = collectAnswerRate;

        if (collectAnswerRate == "100")　//正解率が100％であればスタンプの表示
        {
            subarashiCanvasGroup.DOFade(0.9f, 2f);
        }
    }

    void Update()
    {

    }
}
