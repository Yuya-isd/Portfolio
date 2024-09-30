using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    StateManager state = new StateManager();

    private GameObject player;
    private Vector3 offset;
    private Vector3 playercpy;

    //int stateid;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        //this.player = GameObject.FindGameObjectWithTag("Player");

        offset = transform.position - player.transform.position;

        playercpy = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーがnullなら検知を通す
        if (player == null) this.player = GameObject.Find("Player");

        
        state.stateid = 0;
        if (state.stateid != 2 && state.stateid != 3) 
        {
            if (player != null)
            {
                offset = playercpy;
                transform.position = player.transform.position + offset;
                transform.rotation = Quaternion.Euler(30, 110, 0);
            }
        }
        else if(state.stateid==3)
        {
            transform.position = new Vector3(1000.0f, 0.0f, -10.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
