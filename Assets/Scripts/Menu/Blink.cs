/*
Viaud Guillaume 20/10/2015

Blink spécifique pour boutton du menu 

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink : MonoBehaviour {

    public bool etape = false;
    public GameObject ButtonOK;
    float fade = 1.0f;

    // Use this for initialization
    void Start () {
    
    }

    // Update is called once per frame
    void Update()
    {

        bool pass = true;

        if ( !GetComponent<Button>().interactable )
            pass = false;

        if (name == "ButtonValider")
        {
            if (ButtonOK.activeInHierarchy)
            { 
                GetComponent<Image>().color = new Color(1, 1, 1, 1);
                pass = false;
            }
        }

        if (pass)
        {
            if (!etape)
            {
                fade -= Time.deltaTime * 1.25f;
                GetComponent<Image>().color = new Color(1, 1, 1, fade);
                if (fade <= 0.3f)
                {
                    etape = true;
                }
            }
            else if (etape)
            {
                fade += Time.deltaTime * 1.25f;
                GetComponent<Image>().color = new Color(1, 1, 1, fade);
                if (fade >= 0.99f)
                {
                    etape = false;
                }
            }
        }



    }

}


