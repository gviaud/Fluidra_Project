/*
Viaud Guillaume 20/10/2015

Blink pour boutton du menu

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink_Script : MonoBehaviour {

    public bool etape = false;
    float fade = 1.0f;

    // Use this for initialization
    void Start () {
    
    }

    // Update is called once per frame
    void Update()
    {

        fade = GetComponent<Image>().color.a;
        if (!etape)
        {if (fade<1.0f)
			{
            fade += Time.deltaTime * 3.0f;
            GetComponent<Image>().color = new Color(1, 1, 1, fade);
			}
            if (Input.anyKeyDown)
                etape = true;
            
        }
        else if (etape)
        {

            fade -= Time.deltaTime * 2.0f;
            GetComponent<Image>().color = new Color(1, 1, 1, fade);
            if (GetComponent<Image>().color.a <= 0.01f)
            {
                etape = false;
                transform.parent.gameObject.SetActive(false);
            }

        }
        
    }

    public void changeEtape(bool _bool)
    {

        etape = _bool;
    }

}


