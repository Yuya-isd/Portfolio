using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCamera : MonoBehaviour
{
    private float time;
    bool Turn;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3 && 5 > time)
        {
            transform.position += new Vector3(0, 0.035f, -0.05f);
            Turn = true;
        }
        else if (time > 5 && 8 > time) 
        {
            if (Turn == true) 
            {
                transform.position += new Vector3(-2, -4, -7);
                transform.rotation = Quaternion.Euler(-20, 90, 0);
                Turn = false;
                
            }
            transform.position += new Vector3(0, 0.035f, -0.05f);
        }
        else if (time > 8)
        {
            transform.position = new Vector3(0, 13, -17);
            transform.rotation = Quaternion.Euler(10, 0, 0);
        }
    }
}
