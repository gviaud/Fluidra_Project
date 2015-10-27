using UnityEngine;
using System.Collections;

public class Spa_Script : MonoBehaviour {

    Vector3 init_Position;
    
    Material shell;
    Material skirt;
    Material leather;
    GameObject plage;
    

    //WATER
    GameObject water;
    float init_Bias_Pump;
    bool pump_is_activ;

    enum POSITIONMODE
    {

        AboveGround,
        Semi_Bury,
        Bury

    } POSITIONMODE position_Mode;

    // Use this for initialization
    void Start ()
    {

        init_Position = transform.position;

        shell = transform.FindChild("SPA").GetComponent<Renderer>().materials[0];
        skirt = transform.FindChild("SPA").GetComponent<Renderer>().materials[4];
        leather = transform.FindChild("SPA").GetComponent<Renderer>().materials[5];

        plage = transform.FindChild("plage").gameObject;

        //mask = transform.FindChild("SPA").gameObject;

        water = transform.FindChild("Pool").FindChild("Water").gameObject;
        init_Bias_Pump = water.GetComponent<Renderer>().material.GetFloat("_Bias");
        pump_is_activ = false;
        position_Mode = POSITIONMODE.AboveGround;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void Change_Texture(Material _mat, Texture _tex)
    {
        _mat.mainTexture = _tex;
    }

    public void Activ_Pump()
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


    public void Position_Mode(int _value)
    {

        if(_value == 1)
        {
            AboveGround();
            position_Mode = POSITIONMODE.AboveGround;
        }
        else if (_value == 2)
        {
            Semi_Bury();
            position_Mode = POSITIONMODE.Semi_Bury;
        }
        else if (_value == 3)
        {
            Bury();
            position_Mode = POSITIONMODE.Bury;
        }

    }

    void AboveGround()
    {

        plage.transform.localPosition = new Vector3(-1, 0, -1);
        //mask.transform.localPosition = new Vector3(0, 0, 0);
        transform.position = init_Position - new Vector3(0, 0, 0);

    }
    void Semi_Bury()
    {

        plage.transform.localPosition = new Vector3(-1, 0.4f, - 1);
        //mask.transform.localPosition = new Vector3(0, 0.4f, 0);
        transform.position = init_Position - new Vector3(0, 0.4f, 0);

    }
    void Bury()
    {

        plage.transform.localPosition = new Vector3(- 1, 0.85f, -1);
        //mask.transform.localPosition = new Vector3(0, 0.85f, 0);
        transform.position = init_Position - new Vector3(0, 0.85f, 0);

    }
    



    public Material GetShell()
    {
        return shell;
    }
    public Material GetSkirt()
    {
        return skirt;
    }
    public Material GetLeather()
    {
        return leather;
    }
    public GameObject GetWater()
    {
        return water;
    }

}
