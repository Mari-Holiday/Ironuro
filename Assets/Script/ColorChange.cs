using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    /* 画面タップからのRayでくまの衝突判定、
    　　そのくまの鉛筆の先からのRayでohanaの衝突判定 */

    //各オブジェクト衝突判定用
    GameObject tapKuma;
    GameObject tapOhana;

    //くまとohanaが衝突したPosition
    private Vector2 kumahana;

    //各パーティクル
    static GameObject particlePrefab;
    static GameObject wrongParticlePrefab;

    void Start()
    {
        //パーティクルプレファブ取得
        particlePrefab = (GameObject)Resources.Load("Particle");
        wrongParticlePrefab = (GameObject)Resources.Load("WrongParticle");
    }

    void Update()
    {
        //タッチされたら判定
        if (Input.GetMouseButtonDown(0))
        {
            //タッチ場所からRayを飛ばし、当たったオブジェクトを保持
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, 10);

            //当たったオブジェクトをチェック
            if (hit2d.Length >= 0)
            {
                for (int i = 0; i < hit2d.Length; i++)
                {
                    if (hit2d[i].transform.gameObject.tag == "kuma") //くまオブジェクトにRayが当たっていたら
                    {
                        tapKuma = hit2d[i].transform.gameObject;

                        //ペン先がohanaに当たってるか確認するメソッド呼び出し    
                        changeOhanaColor();
                    }
                }
            }
        }
    }


    void changeOhanaColor()
    {
        //ペン先からRayを飛ばすため、くま自体のPositionから計算してペン先のPosisionを取得
        if (tapKuma.GetComponent<KumaMoveScript>().getKumaDirection())
        { //右向き
            kumahana = new Vector2(tapKuma.transform.position.x + 0.8f, tapKuma.transform.position.y + 0.4f);
        }
        else
        { //左向き
            kumahana = new Vector2(tapKuma.transform.position.x + -0.8f, tapKuma.transform.position.y + 0.4f);
        }

        //ペン先から新しいRayを作成、当たったオブジェクトを保持
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.origin = kumahana;
        RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, 10);

        for (int j = 0; j < hit2d.Length; j++)
        {
            //Rayが当たったオブジェクトのtagがOhanaだったら
            if (hit2d[j].collider.tag == "ohana")
            {
                tapOhana = hit2d[j].transform.gameObject;

                Debug.Log("kumahanaからのRayがohanaにヒット");

                //クマペンの色を取得、お花に適応
                GameObject kumaPen = tapKuma.transform.Find("kumapen").gameObject;
                SpriteRenderer kumaPenSprite = kumaPen.GetComponentInChildren<SpriteRenderer>();
                tapOhana.GetComponent<SpriteRenderer>().color = kumaPenSprite.color;

                //パーティクル作成
                GameObject particle;
                if (tapOhana.GetComponent<PointClass>().collectColor
                    == kumaPenSprite.color) //正解だった場合（sameColorでは間に合わないため直判定）
                {
                    particle = Instantiate(particlePrefab, kumahana, Quaternion.identity);
                }
                else //不正解だった場合 
                {
                    particle = Instantiate(wrongParticlePrefab, kumahana, Quaternion.identity);
                }
                particle.GetComponent<ParticleSystem>().Emit(1);
                Destroy(particle, (float)particle.GetComponent<ParticleSystem>().main.duration);

                //現在の色情報を色ぬられるオブジェクトのポイントクラスに格納
                tapOhana.GetComponent<PointClass>().nowColor = kumaPenSprite.color;
            }
        }
    }

}

