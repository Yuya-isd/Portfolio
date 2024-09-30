using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSeven : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1 && 2.5 > time) 
        {
            transform.position += new Vector3(0, -0.035f, 0);
        }

        if (Input.GetKey(KeyCode.F))
        {
            Scene loadScene = SceneManager.GetActiveScene();

            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
    }
}
