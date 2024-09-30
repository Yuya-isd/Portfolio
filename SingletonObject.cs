using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObject : MonoBehaviour
{
    private static GameObject mInstance;

    //Don't DestroyしているオブジェクトのInstance状態を返す関数
    public static GameObject GetInstance()
    {
        return mInstance;
    }

    void Awake()
    {
        if(mInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            mInstance = gameObject;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
