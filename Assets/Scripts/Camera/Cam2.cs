using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cam2 : MonoBehaviour {

    public GameObject cam2;
    Button buttonEnseigne;

	// Use this for initialization
	void Start ()
    {

        buttonEnseigne = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (cam2.activeInHierarchy)
            buttonEnseigne.interactable = false;
        else
            buttonEnseigne.interactable = true;
    }
}
