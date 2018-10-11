﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelScript : MonoBehaviour
{
    public static level choisedLevel;

    //レベル1（単色）の色をインスペクター上から選択
    public kumaCOL level1Color;

    public SpriteRenderer[] ohanas;
    public Button[] buttons = new Button[3];

    void Start()
    {
        Debug.Log("イベント登録するよ");

        for (int i = 0; i < buttons.Length; i++)
        {
            int n = i; //呼び出し時iのアドレスを参照してしまうため、ループ内で新変数nを宣言、当時のiの値を代入

            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() =>
           checkLevel((level)Enum.ToObject(typeof(level), n + 1)));
        }

    }

    void OnDisable()
    {
        for (int i = 0; i < buttons.Length; i++) //終了時イベントの削除
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }

    public void checkLevel(level choiseLevel)
    {
        Debug.Log("level = " + choiseLevel);

        if (choiseLevel == level.lower) //単色レベル
        {
            KumaCreate.oneColorNum = (int)level1Color;

            //ohanaを全同色に設定
            foreach (SpriteRenderer ohana in ohanas)
            {
                ohana.color = KumaColor.Instance.chosePenColor((int)level1Color);
                Debug.Log(level1Color);
            }
        }
        if (choiseLevel == level.middle) //色ありのみレベル
        {
            KumaCreate.startColorNumCount = 2;
            ohanaColorSet();
        }
        if (choiseLevel == level.upper) //邪魔あり全色レベル
        {
            KumaCreate.startColorNumCount = 0;
            ohanaColorSet();
        }

        choisedLevel = choiseLevel;

        StartCoroutine(screenChange()); //1秒（アニメーション再生）後にIntoroduce画面へ遷移
    }

    private IEnumerator screenChange()
    {
        yield return new WaitForSeconds(1.0f); //コルーチンで1秒待機
        GameTimeControl.levelChoise = false;
    }

    void ohanaColorSet() //カラフル花のセットメソッド
    {
        ohanas[0].color = ohanas[2].color = ohanas[4].color = KumaColor.Instance.chosePenColor(3);
        ohanas[1].color = ohanas[3].color = ohanas[5].color = KumaColor.Instance.chosePenColor(2);
        ohanas[6].color = KumaColor.Instance.chosePenColor(4);
        ohanas[7].color = ohanas[8].color = KumaColor.Instance.chosePenColor(5);
    }
}
