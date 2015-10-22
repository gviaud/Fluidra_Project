using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutINOUT : MonoBehaviour {
    public GameObject  aprpos;
    public float speed =3500f;
    private float x;
    public Button buthelp;
    public bool etape = false;
    // Use this for initialization
    void Start () {
        
    }
	void OnEnable()
    {
        buthelp.interactable = false;
        x = 1538f;
      
    }
	// Update is called once per frame
	void Update ()
    {

       
        if (!etape)
        {
            buthelp.interactable = false;
            if (x > 580f)
            {
                    x -= Time.deltaTime * speed;
                    aprpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 384);
                  
            }
            if ((x > 512f)&&(x<580f))
            {
                print("c'est boooon");
                x -= Time.deltaTime * speed;
                aprpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(512f, 384);

            }
            if (Input.anyKeyDown)
                etape = true;

        }
        else if (etape)
        {
           
            x -= Time.deltaTime * speed;
            aprpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 384);
            if (x<(-519))
            {
             
                etape = false;
                transform.gameObject.SetActive(false);
                x = 1538f;
                
            }
            


        }

    }
    void OnDisable()
    {
        buthelp.interactable = true;
    }
    public void changeEtape(bool _bool)
    {

        etape = _bool;
    }
   
}
