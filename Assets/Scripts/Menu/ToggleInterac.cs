using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleInterac : MonoBehaviour {
    public Toggle but;
    public Image img;
    public Text txt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!but.interactable)
        {
            img.color = new Color(1, 1, 1, 0.2f);
            txt.color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            img.color = new Color(1, 1, 1, 1);
            txt.color = new Color(1, 1, 1, 1);
        }
    }
}