using UnityEngine;
using System.Collections;

public class Spa_Script : MonoBehaviour {

    Vector3 init_Position;
    
    GameObject shell;
    GameObject skirt;
    GameObject plage;
    GameObject mask;

    //WATER
    GameObject water;
    float init_Bias_Pump;
    bool pump_is_activ;

    // Use this for initialization
    void Start ()
    {

        init_Position = transform.position;

        shell = transform.FindChild("coque").gameObject;
        skirt = transform.FindChild("jupe").gameObject;
        plage = transform.FindChild("plage").gameObject;
        mask = transform.FindChild("mask").gameObject;

        water = transform.FindChild("Pool").FindChild("Water").gameObject;
        init_Bias_Pump = water.GetComponent<Renderer>().material.GetFloat("_Bias");
        pump_is_activ = false;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F1))
            AboveGround();
        else if (Input.GetKeyDown(KeyCode.F2))
            Semi_Bury();
        else if (Input.GetKeyDown(KeyCode.F3))
            Bury();
        else if (Input.GetKeyDown(KeyCode.F4))
            Activ_Pump();
        else if (Input.GetKeyDown(KeyCode.F5))
            water.GetComponent<Vidange>().EmptySPA();
        else if (Input.GetKeyDown(KeyCode.F6))
            water.GetComponent<Vidange>().FillSpa();
    }

    void Change_Texture(GameObject _gameObject, Texture _tex)
    {
        if(_gameObject != null && ( _gameObject == shell || _gameObject == skirt))
            _gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
    }


   
    
    void Activ_Pump()
    {

        pump_is_activ = !pump_is_activ;

        if (pump_is_activ)
        {

            water.GetComponent<Renderer>().material.SetFloat("_Bias",25);

        }
        else
        {

            water.GetComponent<Renderer>().material.SetFloat("_Bias", init_Bias_Pump);

        }

    }


    

    void AboveGround()
    {

        plage.transform.localPosition = new Vector3(0, 0, 0);
        mask.transform.localPosition = new Vector3(0, 0, 0);
        transform.position = init_Position - new Vector3(0, 0, 0);

    }
    void Semi_Bury()
    {

        plage.transform.localPosition = new Vector3(0, 0.4f, 0);
        mask.transform.localPosition = new Vector3(0, 0.4f, 0);
        transform.position = init_Position - new Vector3(0, 0.4f, 0);

    }
    void Bury()
    {

        plage.transform.localPosition = new Vector3(0, 0.85f, 0);
        mask.transform.localPosition = new Vector3(0, 0.85f, 0);
        transform.position = init_Position - new Vector3(0, 0.85f, 0);

    }
    



    public GameObject GetShell()
    {
        return shell;
    }
    public GameObject GetSkirt()
    {
        return skirt;
    }

}
