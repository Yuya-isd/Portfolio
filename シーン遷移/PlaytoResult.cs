using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytoResult : MonoBehaviour
{
    private GameObject mPlayer;

    private Player mPlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mPlayer) mPlayer = GameObject.Find("Player");
        if (!mPlayerScript) mPlayerScript = GameObject.Find("Player").GetComponent<Player>();

        //ゴールマスに着いたら遷移を掛ける
        if (mPlayerScript.serchMasTag(mPlayer, "Mas").Contains("Goal"))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("EDScene");
    }
}
