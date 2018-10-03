using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KumaMoveScript : MonoBehaviour
{
    Vector2 force = new Vector2(0.0f, 1.0f);
    Rigidbody2D rb;
    Vector2 prevPos;



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //力を与え続けるため、動き続ける
        rb.AddForce(force);

        //絵柄の回転を阻止
        gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        prevPos = gameObject.transform.position;
    }

    //冒頭でRigidbodyコンポーネントを読み込みしてるためイベント登録なしでOK
    void OnCollisionExit2D(Collision2D c)
    {
        float x = this.transform.position.x - prevPos.x;
        float y = this.transform.position.y - prevPos.y;

        force = new Vector2(x, y).normalized;
    }
}
