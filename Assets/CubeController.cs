using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

    //当たり判定
    private bool hit = false;

    //オーディオソース格納用
    private AudioSource sound01;



	// Use this for initialization
	void Start () {

        //オーディオソースを取り込む
        sound01 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //キューブを破壊する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
        {
            sound01.PlayOneShot(sound01.clip);
        }
    }
}
