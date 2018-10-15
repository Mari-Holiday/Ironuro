using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Rigidbodyのアタッチを強制
public class KumaMoveScript : MonoBehaviour
{
    /* くまオブジェクトにアタッチ、縦横無尽な動きと向き固定を制御 */

    //動きの制御用
    Vector2 force = new Vector2(0.0f, 2.0f);
    Rigidbody2D rb;
    float speedLevel = 6.0f;

    //進行方向を保持
    Vector2 prevPos;
    private bool kumaDirection = true;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        switch (LevelScript.choisedLevel)
        {
            case level.lower:
                speedLevel = 6.0f;
                break;
            case level.middle:
                speedLevel = 7.0f;
                break;
            case level.upper:
                speedLevel = 8.0f;
                break;
        }
    }

    void Update()
    {
        //くまの回転を阻止、動く方向によって左右の向きのみ変動
        if (kumaDirection) { gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); } //左向き
        else { gameObject.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f); } //右向き

        speedControl(); //常にスピードの確認
    }

    void FixedUpdate()
    {
        //力を与え続ける
        rb.AddForce(force);

        speedControl();　//力を与えるごとにスピードの確認

        //現在のPosisionを保持
        prevPos = gameObject.transform.position;
    }

    //別のColliderに衝突したら、力を与える方向を跳ね返りの進行方向に上書き
    void OnCollisionExit2D(Collision2D c)　//衝突判定
    {
        float x = this.transform.position.x - prevPos.x;
        float y = this.transform.position.y - prevPos.y;

        force = new Vector2(x, y).normalized;

        if (x < 0) { kumaDirection = false; } //x0が中央、そのため右向き
        else { kumaDirection = true; }　//左向き
    }

    public bool getKumaDirection()
    {
        return kumaDirection;
    }

    private void speedControl()
    {
        //スピードの制御
        if (rb.velocity.magnitude > speedLevel)
        {
            rb.velocity = rb.velocity * (speedLevel / rb.velocity.magnitude);
        }
    }

}
