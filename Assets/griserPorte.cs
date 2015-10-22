using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class griserPorte : MonoBehaviour
{
    public Button but;
    public Text txt;
    public Text txt2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!but.interactable)
        {
            txt.color = new Color(1, 1, 1, 0.2f);
            txt2.color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            txt.color = new Color(1, 1, 1, 1);
            txt2.color = new Color(1, 1, 1, 1);
        }
    }
}