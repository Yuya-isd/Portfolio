using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouadAll : MonoBehaviour
{
    //コイン
    public AudioClip sound1;

    //アイテム
    public AudioClip sound2;

    //ダイス
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //お金の音を出す
    public void SoundMoney()
    {
        audioSource.PlayOneShot(sound1);
    }
    //アイテムの音を出す
    public void SoundItem()
    {
        audioSource.PlayOneShot(sound2);
    }
    //ダイスの音を出す
    public void SoundDice()
    {
        audioSource.PlayOneShot(sound3);
    }

}
