using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PosbuttonOK : MonoBehaviour
{
    public GameObject menuSide;
    public GameObject menuSecond;
    
    public GameObject ok;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (menuSide.transform.GetChild(0).gameObject.activeInHierarchy )
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 322);
        }
        else if (menuSide.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 362);
        }
        else if (menuSide.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 255);
        }
        else if (menuSide.transform.GetChild(3).gameObject.activeInHierarchy )
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 206);
        }
        else if (menuSide.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 243);
        }
        else if (menuSide.transform.GetChild(5).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 274);
        }

        else if (menuSecond.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 449);
        }
        else if (menuSecond.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 468);
        }
        else
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 158);
        }

        if (!menuSide.activeInHierarchy)
        {
            if (menuSecond.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 376);
            }
            else if (menuSecond.transform.GetChild(2).gameObject.activeInHierarchy)
            {
                ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 511);
            }
        }
       


    }
}
