using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_WATER_script : MonoBehaviour {

	GameObject Side_Menu;

	Toggle ToggleLight;
	Toggle ToggleJupe;
	
	// Use this for initialization
	void Start ()
	{

		ToggleLight = transform.FindChild("ToggleLight").GetComponent<Toggle>();

		Side_Menu = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Background SideMenu").gameObject;
		
		//gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (ToggleLight.isOn) {
			Side_Menu.transform.GetChild (2).gameObject.SetActive (true);
	
		} 
		else 
		{
			Side_Menu.transform.GetChild (2).gameObject.SetActive (false);
		}


	}
}
