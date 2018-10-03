using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{
    List<GameObject> clickedGameObject;

    GameObject tapKuma;
    GameObject tapOhana;

    void Start()
    {

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = new List<GameObject>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, 10);

            if (hit2d[0])
            {
                for (int i = 0; i < hit2d.Length; i++)
                {
                    if (hit2d[i].transform.gameObject == gameObject)
                    {
                        tapKuma = hit2d[i].transform.gameObject;

                        Debug.Log("わたしはくまちゃん" + hit2d[i].transform.gameObject.name + i);

                        for (int j = 0; j < hit2d.Length; j++)
                        {
                            //Rayが当たったオブジェクトのtagがOhanaだったら
                            if (hit2d[j].collider.tag == "ohana")
                            {
                                tapOhana = hit2d[j].transform.gameObject;

                                Debug.Log("Rayがohanaに当たった");
                                tapOhana.GetComponent<SpriteRenderer>().color
                                    = tapKuma.GetComponent<SpriteRenderer>().color;

                            }
                        }
                    }
                }
            }

        }
    }
}

