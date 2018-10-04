using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleScript : MonoBehaviour
{
    Quaternion rotateNormal;

    float timeElapsed;

    void Start()
    {
        rotateNormal = gameObject.GetComponent<Transform>().rotation;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 2.0f)
        {
            gameObject.transform.DOShakeRotation(1f, 15, 5, 10);
            gameObject.transform.rotation = rotateNormal;

            timeElapsed = 0.0f;
        }
    }
}
