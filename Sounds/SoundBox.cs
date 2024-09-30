using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
