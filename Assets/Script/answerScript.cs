﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public GameObject ohanaAnswer;
    public GameObject ohanaPlayed;

    public static string collectAnswerRate;
    public Text collectAnswerRateText;

    void Start()
    {
        GameObject answerClone = GameObject.Instantiate(ohanaAnswer);
        GameObject playedClone = GameObject.Instantiate(ohanaPlayed);

        answerClone.transform.position = new Vector2(-2.25f, 0.55f);
        answerClone.transform.localScale = new Vector2(0.5f, 0.5f);

        playedClone.transform.position = new Vector2(-0.06f, -0.29f);
        playedClone.transform.localScale = new Vector2(1.0f, 1.0f);

        collectAnswerRateText.text = collectAnswerRate;
    }

    void Update()
    {

    }
}