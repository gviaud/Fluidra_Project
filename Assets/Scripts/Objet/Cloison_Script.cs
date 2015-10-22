using UnityEngine;
using System.Collections;

public class Cloison_Script : InteracibleObject_Script {

    public GameObject _lightManager;

    void Awake () 
	{
		//Changetexture (1);
	}

	// Use this for initialization
	void Start () 
	{
		start();
		_name = "Cloison";
        menuSideNum = 0;
        _saveColor = new Color(225.0f / 250.0f, 226.0f / 250.0f, 220.0f / 250.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void activLight(bool b){
		lightIsActiv = b;
		lights.UpdateLight();
	}
	override public void UpdateAll()
	{
		
		_lastMousePos = Input.mousePosition;
	}

	public void Loadtexture()
	{
		Object[] tex_tab = Resources.LoadAll ("Textures");
		GetComponent<MeshRenderer> ().material.mainTexture = (Texture)tex_tab[0];
	}

	public void ChangeColor(int color)
	{

		GetComponent<MeshRenderer> ().material.color = Color.red;

	}

	override public void Changetexture(int num)
	{
		if (num != -1) 
		{
			
			Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;

			if(num < 10)
				tex = Resources.Load ("Textures/0"+num) as Texture;
			else
				tex = Resources.Load ("Textures/"+num) as Texture;

			GetComponent<MeshRenderer> ().material.mainTexture = tex;

			if(GetComponent<Texture_Script>())
				GetComponent<Texture_Script>().tex = num;

		}
	}

	void OnTriggerStay(Collider other)
	{

        if (other.gameObject.tag == "CylinderObj")
        {

            if (other.transform.parent.GetComponent<Light>().enabled)
            {
                _lightManager.GetComponent<LightManager_Script>().nbrLightWallReserve--;
            }

            other.transform.parent.GetComponent<Light>().enabled = false;
            other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;

        }

    }
	
	void OnTriggerExit(Collider other)
	{

        //print (other.gameObject.name);
        if (other.gameObject.tag == "CylinderObj")
        {

            if (!other.transform.parent.GetComponent<Light>().enabled)
            {
                _lightManager.GetComponent<LightManager_Script>().nbrLightWallReserve++;
            }

            other.transform.parent.GetComponent<Light>().enabled = true;
            other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;


        }

    }

}
