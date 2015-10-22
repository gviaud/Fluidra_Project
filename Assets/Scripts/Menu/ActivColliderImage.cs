/*
Viaud Guillaume 20/10/2015

Permet l'activation ou la désactivation du collider de drag and drop dans le menu.

*/


using UnityEngine;
using System.Collections;

public class ActivColliderImage : MonoBehaviour {

    public GameObject SideMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if(SideMenu.transform.GetChild(2).gameObject.activeInHierarchy || SideMenu.transform.GetChild(5).gameObject.activeInHierarchy )
        {
            transform.GetChild(0).GetComponent<Collider>().enabled = true;
        }
        else
            transform.GetChild(0).GetComponent<Collider>().enabled = false;

    }
}
