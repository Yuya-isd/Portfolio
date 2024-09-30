using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //public static implicit operator DontDestroy(StateManager v)
    //{
    //    throw new NotImplementedException();
    //}

    //public static implicit operator DontDestroy(ScoreManager v)
    //{
    //    throw new NotImplementedException();
    //}
}
