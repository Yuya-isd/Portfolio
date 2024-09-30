using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DicetoPlay : MonoBehaviour
{
    MeshRenderer playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = GameObject.Find("Player").GetComponent<MeshRenderer>();
        playerMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Play");
        playerMesh.enabled = true;
    }
}