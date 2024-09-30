using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpMove : MonoBehaviour
{
    private float time;
    private float Stoptime;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Stoptime = 0;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        time += Time.deltaTime;
        if (time > 3)
        {
            if (flag == false)
            {
                transform.position += new Vector3(0, 0.035f, -0.05f);
            }
            else
            {
                Stoptime += Time.deltaTime;
                if(Stoptime>1)
                transform.position += new Vector3(0, 0.1f, 0);
            }
        }
        if (time > 13)
        {
            SceneManager.LoadScene("TitleScene");
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        flag = true;
    }
}
