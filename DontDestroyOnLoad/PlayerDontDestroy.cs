using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDontDestroy : MonoBehaviour
{
    private static bool Loaded { get; set; }

    [SerializeField]
    GameObject[] PlayerPrefabs = null;

    void Awake()
    {
        //すでにロード済みなら、二重に作成しない
        if (Loaded) return;

        Loaded = true;

        //プレハブをインスタンス化して、DontDestroyOnLoad
        foreach (var prefab in PlayerPrefabs)
        {
            GameObject go = Instantiate(prefab);
            DontDestroyOnLoad(go);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
