using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sangre : MonoBehaviour
{

    public Image bloodEffectImage;


    private float r;
    private float g;
    private float b;
    private float a;

    
    void Start()
    {
        r = bloodEffectImage.color.r;
        g = bloodEffectImage.color.g;
        b = bloodEffectImage.color.b;
        a = bloodEffectImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            a += 0.09f;
        }
        a -= 0.006f;

        a = Mathf.Clamp(a, 0, 1f);

        ChangeColor();
    }

        private void ChangeColor()
        {
            Color c = new Color(r,g,b,a);
            bloodEffectImage.color = c;

        } 
}
