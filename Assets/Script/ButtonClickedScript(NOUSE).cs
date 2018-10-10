using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickedScript : MonoBehaviour
{
    [SerializeField]
    GameObject levelScreen;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
           levelScreen.GetComponent<LevelScript>().checkLevel((level)Enum.ToObject(typeof(level), 1)));
    }

    void Update()
    {

    }
}
