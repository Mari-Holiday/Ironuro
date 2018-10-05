using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{
    GameObject tapKuma;
    GameObject tapOhana;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, 10);

            if (hit2d.Length >= 0)
            {
                for (int i = 0; i < hit2d.Length; i++)
                {
                    if (hit2d[i].transform.gameObject == gameObject)
                    {
                        tapKuma = hit2d[i].transform.gameObject;

                        Debug.Log("わたしはくまちゃん" + hit2d[i].transform.gameObject.name + hit2d[i].transform.gameObject.transform.position);

                        //くま本体に当たったら、ペン先がohanaに当たってるか確認するためメソ呼び出し                        
                        changeOhanaColor();
                    }
                }
            }
        }
    }

    void changeOhanaColor()
    {
        Vector2 kumahana;

        //ペン先からRayを飛ばすため、くま自体のPositionから計算してペン先のPosisionを取得
        if (tapKuma.GetComponent<KumaMoveScript>().getKumaDirection())
        { //右向き
            kumahana = new Vector2(tapKuma.transform.position.x + 0.8f, tapKuma.transform.position.y + 0.4f);
        }
        else
        { //左向き
            kumahana = new Vector2(tapKuma.transform.position.x + -0.8f, tapKuma.transform.position.y + 0.4f);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.origin = kumahana;

        RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, 10);

        for (int j = 0; j < hit2d.Length; j++)
        {
            //Rayが当たったオブジェクトのtagがOhanaだったら
            if (hit2d[j].collider.tag == "ohana")
            {
                tapOhana = hit2d[j].transform.gameObject;

                Debug.Log("kumahanaからのRayがohanaに当たった");

                //クマペンの色を取得、お花に適応
                GameObject kumaPen = tapKuma.transform.Find("kumapen").gameObject;
                SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
                tapOhana.GetComponent<SpriteRenderer>().color = kumaPenSprite.color;
            }
        }
    }

}

