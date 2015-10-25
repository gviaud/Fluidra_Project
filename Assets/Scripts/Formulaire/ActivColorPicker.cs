using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivColorPicker : MonoBehaviour {

    public Toggle lightToggle;
    public GameObject sideMenuWaterLight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (lightToggle.isOn)
            sideMenuWaterLight.SetActive(true);
    }
}
