using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fleche3D_Script : MonoBehaviour {

    float destroyTimer;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        destroyTimer = 1000;
    }
	
	// Update is called once per frame
	void Update () {

        if (name == "Background AideMultiFace2")
        {

            transform.parent.FindChild("Background AideMultiFace").GetComponent<Fleche3D_Script>().destroyTimer = 0;
        }

            destroyTimer -= Time.deltaTime;
        if (Input.anyKeyDown)
        {
            destroyTimer = 4.0f;
        }


        if (destroyTimer <= 0)
            gameObject.SetActive(false);
        else if (destroyTimer <= 4)
        {
            transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color.a - Time.deltaTime / 2.0f);
            if (name == "Background AideCloison")
                transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
            else if (name == "Background AideReserve")
            {
                transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color.a - Time.deltaTime / 2.0f);
                transform.GetChild(0).transform.GetChild(1).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(1).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
            }
            else if (name == "Background AideMultiFace")
            {
                transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
            }
			else if (name == "Background AideMultiFace2")
			{
				transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
			}
			else if (name == "Background AideGlisserDeposer")
			{
				transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
			}
			else if (name == "Background AideDeplacerVisuelCloison" || name == "Background AideDeplacerVisuelEnseigne" || name == "Background AideDeplacerVisuelEnseigneBack")
			{
				transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color.a - Time.deltaTime / 2.0f);
				transform.GetChild(0).transform.GetChild(1).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(1).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
			}
        }

		if (name == "Background AideCloison" || name == "Background AideMultiFace2")
			plus ();
    }

	void plus()
	{

		if (destroyTimer <= 4)
		{
			transform.GetChild(1).transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color.a - Time.deltaTime / 2.0f);
			if (name == "Background AideCloison")
				transform.GetChild(1).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
			else if (name == "Background AideMultiFace2")
			{
				transform.GetChild(1).transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1, 1, 1, transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().color.a - Time.deltaTime / 2.0f);
			}
		}
		
	}

}

