/*
Viaud Guillaume 20/10/2015

Rend les bouttons de lumiere interactable ou pas suivant si l'objet existe ou pas

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightMenu : MonoBehaviour {


    private SceneManager_Script sceneManager;

    private Toggle cloisonG;
    private Toggle cloisonM;
    private Toggle cloisonD;
    private Toggle reserve;
    private Toggle enseigne;

    private bool start = false;

    // Use this for initialization
    void Start()
    {
        
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager_Script>();

        cloisonG = transform.GetChild(0).GetComponent<Toggle>();
        cloisonM = transform.GetChild(1).GetComponent<Toggle>();
        cloisonD = transform.GetChild(2).GetComponent<Toggle>();
        reserve = transform.GetChild(3).GetComponent<Toggle>();
        enseigne = transform.GetChild(4).GetComponent<Toggle>();

        start = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!start)
            Start();

        if (sceneManager.Wall_Tab[0].activeInHierarchy)
            cloisonM.interactable = true;
        else
            cloisonM.interactable = false;

        if (sceneManager.Wall_Tab[1].activeInHierarchy)
            cloisonG.interactable = true;
        else
            cloisonG.interactable = false;

        if (sceneManager.Wall_Tab[2].activeInHierarchy)
            cloisonD.interactable = true;
        else
            cloisonD.interactable = false;

        if (sceneManager._Reserve.activeInHierarchy)
            reserve.interactable = true;
        else
            reserve.interactable = false;

        if (sceneManager._Enseigne.activeInHierarchy)
            enseigne.interactable = true;
        else
            enseigne.interactable = false;

    }
}
