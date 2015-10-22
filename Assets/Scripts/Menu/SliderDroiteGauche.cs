using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderDroiteGauche : MonoBehaviour {

    public SceneManager_Script sceneManagerScript;
    Slider slider;

    int maxValue;
    int minValue;

    // Use this for initialization
    void Start ()
    {
        slider = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sceneManagerScript._reserveLongueur == 2 && sceneManagerScript._reserveLargeur == 2)
        {
            minValue = -6 ;
            maxValue = 6;
        }
        else if (sceneManagerScript._reserveLargeur == 1)
        {
            minValue = -sceneManagerScript._reserveLongueur * 2 ;
            maxValue = sceneManagerScript._reserveLongueur * 2;
        }
        else if (sceneManagerScript._reserveLargeur == 2)
        {
            minValue = -sceneManagerScript._reserveLargeur * 2 ;
            maxValue = sceneManagerScript._reserveLargeur * 2;
        }
		else
		{
			minValue = -sceneManagerScript._reserveLargeur * 2 ;
			maxValue = sceneManagerScript._reserveLargeur * 2;
		}

        slider.maxValue = maxValue;
        slider.minValue = minValue;

    }
}
