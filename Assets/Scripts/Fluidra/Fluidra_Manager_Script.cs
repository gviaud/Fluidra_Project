using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fluidra_Manager_Script : MonoBehaviour {

    bool block_Input;

    GameObject spa_GO;
    GameObject spa_GO_2;

    ParticleSystem spark_Particle_System;
    Image fluidra_Transition_Image;

    float speed = 0;

    GameObject Side_Menu;
    GameObject Second_Menu;

    Color init_Color;
    bool light_Is_Activ;
    Light sun;

    GameObject ColorPicker;
    GameObject CubeGenerator;

    // Use this for initialization
    void Start ()
    {

        spa_GO = transform.FindChild("SM240_Ref").gameObject;
        spa_GO_2 = transform.FindChild("SM240_Ref (1)").gameObject;

        fluidra_Transition_Image = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Fluidra_Transition_GUI").GetComponent<Image>();
        Side_Menu = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Background SideMenu").gameObject;
        Second_Menu = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Background SecondMenu").gameObject;
        CubeGenerator = transform.FindChild("CubeGenerator").gameObject;

        spark_Particle_System = transform.FindChild("Spark").GetComponent<ParticleSystem>();
        spark_Particle_System.Stop();

        spa_GO_2.SetActive(false);

        init_Color = new Color(124.0f/255.0f, 240.0f / 255.0f, 1, 1);
        light_Is_Activ = true;

        sun = transform.FindChild("Sun").GetComponent<Light>();
        ColorPicker = Side_Menu.transform.GetChild(2).FindChild("ColorPicker").gameObject;

        block_Input = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void Change_Object()
    {

        if (Verification())
        {
            block_Input = true;
            StartCoroutine(ChangeSpa(0.2f));

        }
    }

    IEnumerator ChangeSpa(float delayTime)
    {

        //SPARK
        spark_Particle_System.Play();
        spark_Particle_System.emissionRate = 1;
        spark_Particle_System.startSize = 0.1f;
        spark_Particle_System.Stop();
        GameObject spa;
        if (spa_GO.activeInHierarchy)
            spa = spa_GO;
        else
            spa = spa_GO_2;

        yield return new WaitForSeconds(delayTime); // start at time X

        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        int turn = 1;
        float lastRotY = 0;
        while (turn < 2)
        {

            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed += 2.0f * (turn*4) * Time.deltaTime;
            spark_Particle_System.emissionRate += Time.deltaTime * 1000;
            if( turn >= 0)
            {
                //fluidra_Transition_Image.color = new Color(1,1,1, (fluidra_Transition_Image.color.a + Time.deltaTime));
                spark_Particle_System.startSize += Time.deltaTime/5.0f;
            }
            //print(spa.transform.eulerAngles.y + " " + lastRotY);
            if (lastRotY > spa.transform.eulerAngles.y)
                turn++;
            lastRotY = spa.transform.eulerAngles.y;
            yield return 0;

        }
       

        if (spa_GO.activeInHierarchy)
        {
            spa_GO.SetActive(false);
            spa_GO_2.SetActive(true);
            spa = spa_GO_2;
        }
        else
        {
            spa_GO_2.SetActive(false);
            spa_GO.SetActive(true);
            spa = spa_GO;
        }
    
        turn = 1;
        while (turn < 2)
        {
            spark_Particle_System.startSize -= Time.deltaTime;
            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed -= 2.0f * (turn * 4) * Time.deltaTime;
            spark_Particle_System.emissionRate -= Time.deltaTime * 1000;
            //fluidra_Transition_Image.color = new Color(1, 1, 1, fluidra_Transition_Image.color.a - Time.deltaTime);
            if (lastRotY > spa.transform.eulerAngles.y)
                turn++;
            lastRotY = spa.transform.eulerAngles.y;
            yield return 0;

        }

        fluidra_Transition_Image.color = new Color(1, 1, 1, 0);
        spa.transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForEndOfFrame();

        spark_Particle_System.Stop();

        speed = 0;
        block_Input = false;

    }

    public void CloseMenu()
    {

        Side_Menu.transform.GetChild(0).gameObject.SetActive(false);
        Side_Menu.transform.GetChild(1).gameObject.SetActive(false);
        Second_Menu.transform.GetChild(0).gameObject.SetActive(false);
        Second_Menu.transform.GetChild(1).gameObject.SetActive(false);
        Side_Menu.transform.GetChild(2).gameObject.SetActive(false);
        //ColorPicker.SetActive(false);

    }

    bool Verification()
    {

        if (Side_Menu.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            Side_Menu.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (Side_Menu.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            Side_Menu.transform.GetChild(1).gameObject.SetActive(false);
        }
        return !block_Input;
    }
    public bool Input_Is_Block()
    {
        return block_Input;
    }

    public void Change_Texture_Shell(Texture _tex)
    {
        if (Verification())
            Get_Spa().GetComponent<Spa_Script>().Change_Texture(Get_Spa().GetComponent<Spa_Script>().GetShell(), _tex);

    }
    public void Change_Texture_Skirt(Texture _tex)
    {
        if (Verification())
            Get_Spa().GetComponent<Spa_Script>().Change_Texture(Get_Spa().GetComponent<Spa_Script>().GetSkirt(), _tex);

    }
    public void Emptying()
    {
        if (Verification())
            Get_Spa().GetComponent<Spa_Script>().GetWater().GetComponent<Vidange>().Emptying();
    }
    public void Pump()
    {
        if (Verification())
            Get_Spa().GetComponent<Spa_Script>().Activ_Pump();
    }
    public void Position_Mode(float _value)
    {
        if (Verification())
            Get_Spa().GetComponent<Spa_Script>().Position_Mode((int)_value);
    }
    
    public void Activ_Light()
    {
        light_Is_Activ = !light_Is_Activ;


        if (!light_Is_Activ)
        {
            Get_Spa().GetComponent<Spa_Script>().GetWater().transform.FindChild("WaterLight").GetComponent<Light>().enabled = light_Is_Activ;
            Get_Spa().GetComponent<Spa_Script>().GetWater().GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0, 1));
        }
        else if (light_Is_Activ)
        {
            Get_Spa().GetComponent<Spa_Script>().GetWater().transform.FindChild("WaterLight").GetComponent<Light>().enabled = light_Is_Activ;
            Get_Spa().GetComponent<Spa_Script>().GetWater().GetComponent<Renderer>().material.SetColor("_Color", init_Color);
        }
        

       

    }

    public void Change_Water_Color(Color _color)
    {

        Get_Spa().GetComponent<Spa_Script>().GetWater().transform.FindChild("WaterLight").GetComponent<Light>().color = _color;
        Get_Spa().GetComponent<Spa_Script>().GetWater().GetComponent<Renderer>().material.SetColor("_Color", _color);

    }

    GameObject Get_Spa()
    {

        if (spa_GO.activeInHierarchy)
            return spa_GO;
        else
            return spa_GO_2;

    }

}
