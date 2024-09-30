using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class StateManager : MonoBehaviour
{
    public enum GAMESTATELIST
    {
        NON = 0,
        PLAYER_CHOICE,
        PLAY_DICE,
        PLAY_SLOT,
        PLAYER_MOVE,
        PLAYER_MASS,
        PLAYER_ENTER
    };

    //Instance用の変数
    private static StateManager mStateManagerInstance;

    public static StateManager Instance()
    {
        return mStateManagerInstance;
    }

    void Awake()
    {
        if (mStateManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        mStateManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }


    public int stateid;
    // Start is called before the first frame update
    void Start()
    {
        stateid = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public int StateSet()
    {
        return stateid;
    }
}
