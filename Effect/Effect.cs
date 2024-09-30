using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private Vector3 playercpy;
    //ParticleSystem mParticleSystem;
    //private ParticleSystem.Particle[] mParticles;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを追尾
        this.player = GameObject.Find("Player");
        //this.player = GameObject.FindGameObjectWithTag("Player");

        offset = transform.position - player.transform.position;

        playercpy = transform.position;

        ////エフェクト
        //mParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーがnullなら検知を通す
        if (player == null) this.player = GameObject.Find("Player");

        if (player != null)
        {
            offset = playercpy;
            transform.position = player.transform.position + offset;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        ////必要な場合のみ配列を作成しなおす。
        //int maxParticles = mParticleSystem.main.maxParticles;
        //if(mParticles==null||mParticles.Length<maxParticles)
        //{
        //    mParticles = new ParticleSystem.Particle[maxParticles];
        //}

        ////現在のパーティクルを取得する。
        //int particleNum = mParticleSystem.GetParticles(mParticles);

        ////パーティクル一つ一つの処理
        //for(int i=0;i<particleNum;i++)
        //{

        //}

    }
}
