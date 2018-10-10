using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorClass : MonoBehaviour
{
    public GameObject kumaPenWhite;
    public GameObject kumaPenBlack;
    public GameObject kumaPenRed;
    public GameObject kumaPenBlue;
    public GameObject kumaPenYellow;
    public GameObject kumaPenGreen;

    private static Color penWhite;
    private static Color penBlack;
    private static Color penRed;
    private static Color penBlue;
    private static Color penYellow;
    private static Color penGreen;

    //★クラスフィールドにインスペクター上から代入する方法を調査
    [SerializeField]
    public static Color white;
    [SerializeField]
    private Color black;
    [SerializeField]
    private Color red;
    [SerializeField]
    private Color blue;
    [SerializeField]
    private Color yellow;
    [SerializeField]
    private Color green;


    void Awake()
    {
        //★インスペクター上からクラスフィールドに保持したい
        // penWhite = white;
        // penBlack = black;
        // penRed = red;
        // penBlue = blue;
        // penYellow = yellow;
        // penGreen = green;

        penWhite = kumaPenWhite.GetComponent<SpriteRenderer>().color;
        penBlack = kumaPenBlack.GetComponent<SpriteRenderer>().color;
        penRed = kumaPenRed.GetComponent<SpriteRenderer>().color;
        penBlue = kumaPenBlue.GetComponent<SpriteRenderer>().color;
        penYellow = kumaPenYellow.GetComponent<SpriteRenderer>().color;
        penGreen = kumaPenGreen.GetComponent<SpriteRenderer>().color;

    }

    void Update()
    {

    }

    //引数の番号で各色を返すメソッド
    public static Color chosePenColor(int colorNum)
    {
        if (colorNum == 0) { return penWhite; }
        if (colorNum == 1) { return penBlack; }
        if (colorNum == 2) { return penRed; }
        if (colorNum == 3) { return penBlue; }
        if (colorNum == 4) { return penYellow; }
        if (colorNum == 5) { return penGreen; }
        else { return penWhite; }
    }

    //各色ゲットメソッド
    public static Color getPenWhite()
    {
        return penWhite;
    }
    public static Color getPenBlack()
    {
        return penBlack;
    }
    public static Color getPenRed()
    {
        return penRed;
    }
    public static Color getPenBlue()
    {
        return penBlue;
    }
    public static Color getPenYellow()
    {
        return penYellow;
    }
    public static Color getPenGreen()
    {
        return penGreen;
    }

}
