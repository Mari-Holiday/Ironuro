using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject levelKuma;

    void Start()
    {

    }

    void Update()
    {

    }

    public void levelKumaApper()
    {
        levelKuma.SetActive(true);
        levelKuma.transform.DOPunchScale(new Vector3(1.0f, 1.0f), 1.0f);
    }

    public void levelKumaDisapper(){
        levelKuma.SetActive(false);
    }
}
