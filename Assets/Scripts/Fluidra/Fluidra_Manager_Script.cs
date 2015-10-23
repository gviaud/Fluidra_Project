﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fluidra_Manager_Script : MonoBehaviour {

    bool block_Input;

    GameObject spa_GO;
    GameObject spa_GO_2;

    ParticleSystem spark_Particle_System;
    Image fluidra_Transition_Image;

    float speed = 0;

	// Use this for initialization
	void Start ()
    {

        spa_GO = transform.FindChild("SM240_Ref").gameObject;
        spa_GO_2 = transform.FindChild("SM240_Ref (1)").gameObject;

        fluidra_Transition_Image = GameObject.Find("CameraGUI").transform.GetChild(0).FindChild("Fluidra_Transition_GUI").GetComponent<Image>();

        spark_Particle_System = transform.FindChild("Spark").GetComponent<ParticleSystem>();
        spark_Particle_System.Stop();

        spa_GO_2.SetActive(false);

        block_Input = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if ( !Input_Is_Block() && Input.GetKeyDown(KeyCode.F7))
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

        GameObject spa;
        if (spa_GO.activeInHierarchy)
            spa = spa_GO;
        else
            spa = spa_GO_2;

        yield return new WaitForSeconds(delayTime); // start at time X

        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        int turn = 1;
        float lastRotY = 0;
        while (turn < 4)
        {

            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed += 2.0f * (turn*4) * Time.deltaTime;
            spark_Particle_System.emissionRate += Time.deltaTime * 1000;
            if( turn >= 2)
            {
                fluidra_Transition_Image.color = new Color(1,1,1, (fluidra_Transition_Image.color.a + Time.deltaTime));
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
        while (turn < 4)
        {
            spark_Particle_System.startSize -= Time.deltaTime;
            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed -= 2.0f * (turn * 4) * Time.deltaTime;
            spark_Particle_System.emissionRate -= Time.deltaTime * 1000;
            fluidra_Transition_Image.color = new Color(1, 1, 1, fluidra_Transition_Image.color.a - Time.deltaTime);
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

    public bool Input_Is_Block()
    {

        return block_Input;
    }

}
