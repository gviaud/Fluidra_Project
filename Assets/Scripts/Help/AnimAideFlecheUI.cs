using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimAideFlecheUI : MonoBehaviour {

    bool stop;
    RectTransform rectTransform;
    Vector2 pos;

    bool anim;

    float max = 5f;
    float min = -5f;

    float destroyTimer;
    public Toggle toggle;


    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        pos = rectTransform.anchoredPosition;
        anim = true;
        destroyTimer = 1000;
        stop = false;
        transform.parent.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

		if ( !stop  )
        {
            Vector2 myPos = rectTransform.anchoredPosition;

            if (anim)
            {
                rectTransform.anchoredPosition = new Vector2(myPos.x + Time.deltaTime * 9f, myPos.y);
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(myPos.x - Time.deltaTime * 9f, myPos.y);
            }

            myPos = rectTransform.anchoredPosition;
            if (myPos.x >= pos.x + max)
                anim = false;
            else if (myPos.x <= pos.x + min)
                anim = true;


			if(transform.parent.name != "Background AideEnseigne")
           		Destroy();
        }

    }


    void Destroy()
    {
       
        destroyTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            destroyTimer = 0.0f;
           
        }

        if (destroyTimer <= 0)
        {

            stop = true;
            transform.parent.gameObject.SetActive(false);
        } 
        else if (destroyTimer <= 5)
        {
           GetComponent<Image>().color = new Color(1, 1, 1, GetComponent<Image>().color.a - Time.deltaTime / 5.0f);
           transform.parent.GetChild(1).transform.GetComponent<Text>().color = new Color(1, 1, 1, transform.parent.GetChild(1).transform.GetComponent<Text>().color.a - Time.deltaTime / 5.0f);
        }

        
        
    }
}
