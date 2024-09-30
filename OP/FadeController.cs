using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private float time;
    float fadeSpeed = 0.02f;
    float red, green, blue, alfa;

    public bool isFadeOut = false;

    Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Image>().enabled = true;//オフにしていたPanelのコンポ―ネントをオンに変更
        //GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        //Imageのカラーを変更。Colorの引数は（赤、緑、青、透明度）の順で指定
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            isFadeOut = true;
        }
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if(alfa>=1)
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
