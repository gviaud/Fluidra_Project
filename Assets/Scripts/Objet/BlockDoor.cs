using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockDoor : MonoBehaviour {
    public SceneManager_Script sc;
    public Slider slider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
   
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "canHaveLogo")
        {
            int value = (int)slider.value;
            if (value < 0)
                value++;
            else
                value--;
            slider.value = value;
            sc.SliderPorte();
            /*
            while (value != 0)
            {
                slider.value = value;
                sc.SliderPorte();
                if (value < 0)
                    value++;
                else
                    value--;
            }
            */
        }

    }
}
