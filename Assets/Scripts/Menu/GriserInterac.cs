using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GriserInterac : MonoBehaviour {
    public Button but;
    public Image img;
    public Text txt;
    public Text txt1;
    public Text txt2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!but.interactable)
        { img.color = new Color(1, 1, 1, 0.2f);
          txt.color = new Color(1, 1, 1, 0.2f);
            txt1.color = new Color(1, 1, 1, 0.2f);
            txt2.color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            img.color = new Color(1, 1, 1, 1);
            txt.color = new Color(1, 1, 1, 1);
            txt1.color = new Color(1, 1, 1, 1);
            txt2.color = new Color(1, 1, 1, 1);
        }
	}
}
