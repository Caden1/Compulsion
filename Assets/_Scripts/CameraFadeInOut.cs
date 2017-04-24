using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFadeInOut : MonoBehaviour
{

    Color temp;
    public SpriteRenderer fadePane;
    // Use this for initialization
    void Start()
    {
        temp = fadePane.color;
        temp.a = 0f;
        fadePane.color = temp;
    }
    bool x = true;
    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator FadeIn()
    {
        while (fadePane.color.a > 0)
        {
            temp = fadePane.color;
            temp.a = temp.a - 0.01f;
            if(temp.a < 0)
            {
                temp.a = 0;
            }
            fadePane.color = temp;

            yield return new WaitForSeconds(.03f);
        }
        x = false;
    }
    public IEnumerator FadeOut()
    {
        while (fadePane.color.a < 1)
        {
            temp = fadePane.color;
            temp.a = temp.a + 0.01f;
            if(temp.a > 1)
            {
                temp.a = 1;
            }
            fadePane.color = temp;

            yield return new WaitForSeconds(.03f);
        }
        x = true;
    }
    public IEnumerator func()
    {
        Debug.Log("this");
        yield return new WaitForSeconds(2);
    }
}
