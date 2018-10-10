using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumaColor : SingletonMonoBehaviour<KumaColor>
{
    [SerializeField]
    private Color white;
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

    protected override void Init()
    {
        base.Init(); //親クラス（SingletonMonoBehaviour）のメソッドを呼び出し

        /*　初期化（Start的） 作業が必要であればここに書く */

    }

    public Color chosePenColor(int colorNum)
    {
        if (colorNum == 0) { return white; }
        if (colorNum == 1) { return black; }
        if (colorNum == 2) { return red; }
        if (colorNum == 3) { return blue; }
        if (colorNum == 4) { return yellow; }
        if (colorNum == 5) { return green; }
        else { return white; }
    }

    public Color getWhite(){
        return white;
    }
    public Color getBlack(){
        return black;
    }
    public Color getRed(){
        return red;
    }
    public Color getBlue(){
        return blue;
    }
    public Color getYellow(){
        return yellow;
    }
    public Color getGreen(){
        return green;
    }

}
