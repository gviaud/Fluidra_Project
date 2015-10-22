using UnityEngine;
using System.Collections;

public class ScriptChoix : MonoBehaviour {
    public GameObject Surface;
    public GameObject Choix;
    public GameObject Sol;
    public GameObject Cloison;
    public GameObject Enseigne;
    public GameObject Reserve;
    public GameObject Eclairage;
    public UnityEngine.UI.Text tChoix;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Surface.activeInHierarchy)
        {
            if (Sol.activeInHierarchy)
            {
                Choix.SetActive(true);
                tChoix.text = "SOL";
            }
            else if (Cloison.activeInHierarchy)
            {
                Choix.SetActive(true);
                tChoix.text = "CLOISON";
            }
            else if (Enseigne.activeInHierarchy)
            {
                Choix.SetActive(true);
                tChoix.text = "ENSEIGNE";
            }
            else if (Reserve.activeInHierarchy)
            {
                Choix.SetActive(true);
                tChoix.text = "RESERVE";
            }
            else if (Eclairage.activeInHierarchy)
            {
                Choix.SetActive(true);
                tChoix.text = "ECLAIRAGE";
            }
           
            

        }
        else
        {
            Choix.SetActive(false);
            tChoix.text = "";
        }
	
	}
}
