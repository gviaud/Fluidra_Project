using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_SPA_Script : MonoBehaviour {

    GameObject Side_Menu;

    GameObject group;
    Toggle ToggleCoque;
    Toggle ToggleJupe;

    // Use this for initialization
    void Start ()
    {
        group = transform.FindChild("Group").gameObject;

        ToggleCoque = group.transform.GetChild(0).GetComponent<Toggle>();
        ToggleJupe = group.transform.GetChild(1).GetComponent<Toggle>();

        Side_Menu = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Background SideMenu").gameObject;

        //gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
        if( ToggleCoque.isOn )
        {
            Side_Menu.transform.GetChild(0).gameObject.SetActive(true);
            Side_Menu.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (ToggleJupe.isOn)
        {
            Side_Menu.transform.GetChild(1).gameObject.SetActive(true);
            Side_Menu.transform.GetChild(0).gameObject.SetActive(false);
        }
      
	}
}
