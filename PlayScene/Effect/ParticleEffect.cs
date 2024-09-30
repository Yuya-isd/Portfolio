//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ParticleEffect : MonoBehaviour
//{
//    static int PARTICLE_MONEY = 30000;

//    //パーティクル用変数
//    int ParticleCnt;

//    //パーティクル用配列＆リスト
//    public GameObject[] effect;
//    public List<GameObject> mEffectList = new List<GameObject>();

//    // Start is called before the first frame update
//    void Start()
//    {
//        ParticleCnt = 0;

//        //プレイヤーに付いているエフェクトをタグで検知
//        effect = GameObject.FindGameObjectsWithTag("Particle");
//        mEffectList.AddRange(effect);

//        foreach (GameObject item in mEffectList)
//        {
//            item.SetActive(false);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(mEffectList.Count <= 0)
//        {
//            effect = GameObject.FindGameObjectsWithTag("Particle");
//            mEffectList.AddRange(effect);
//        }

//        if (Moneycpy < m_Money)
//        {
//            //ParticleMoney=30000
//            if (Moneycpy + ParticleMoney <= m_Money)
//            {
//                foreach (GameObject item in mEffectList)
//                {
//                    item.SetActive(true);
//                }
//            }

//            else
//            {

//                mEffectList[0].SetActive(true);

//            }

//            ParticleCnt++;
//        }

//        if (ParticleCnt > 180)
//        {
//            Moneycpy = m_Money;
//            ParticleCnt = 0;

//            foreach (GameObject item in mEffectList)
//            {
//                item.SetActive(false);
//            }
//        }
//    }
//}
