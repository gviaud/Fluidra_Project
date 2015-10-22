using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PosPrix : MonoBehaviour {
    public GameObject menuSide;
    public GameObject menuSecond;
    
    public GameObject ok;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (menuSide.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 369);
        }
        else if (menuSide.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 410);
        }
        else if (menuSide.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 303);
        }
        else if (menuSide.transform.GetChild(3).gameObject.activeInHierarchy )
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 255);
        }
        else if (menuSide.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 290);
        }

             else if (menuSide.transform.GetChild(5).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 321);
        }
      
        
        else if (menuSecond.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 496);
        }
        else if (menuSecond.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 515);
        }
        else
        {
            ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 112);
        }
        if (!menuSide.activeInHierarchy)
        {
            if (menuSecond.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 423);
            }
            else if (menuSecond.transform.GetChild(2).gameObject.activeInHierarchy)
            {
                ok.GetComponent<RectTransform>().anchoredPosition = new Vector2(924, 558);
            }
        }
      

    }
}
