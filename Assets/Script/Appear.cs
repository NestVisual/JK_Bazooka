using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour {

    public GameObject obj;		//敵キャラのプレハブ
    private GameObject[] objs;	//敵キャラを入れておく配列
    public int max;			    //この場所から同時に出現させる人数
    public float appearTime;		//次の敵キャラが出現するまでの時間
    public int total;			    //この場所から敵キャラが出現する回数
    private int num;			    //何人出現したか
    private float currentTime;	//待ち時間の計測に使う

    void Start()
    {
        objs = new GameObject[max];
        currentTime = 0.0f;
        num = 0;
    }

    void Update()
    {
        if (num < total)
        {

            currentTime += Time.deltaTime;

            if (currentTime > appearTime)
            {
                for (int i = 0; i < objs.Length; i++)
                {
                    if (objs[i] == null)
                    {
                        objs[i] = GameObject.Instantiate(obj);
                        num++;
                        break;
                    }
                }
                currentTime = 0.0f;
            }
        }
    }

    
}