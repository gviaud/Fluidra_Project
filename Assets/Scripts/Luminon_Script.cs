using UnityEngine;
using System.Collections;

public class Luminon_Script : MonoBehaviour {

    float timer;

    Material mat;
    Light light;
    Color color_Mat;
    Behaviour haloComponent;
    float size_halo;
    float intensity;

    Behaviour halo;

    // Use this for initialization
    void Start () {

        mat = GetComponent<Renderer>().material;
        light = GetComponent<Light>();

        color_Mat = GetComponent<Renderer>().material.color;
        intensity = GetComponent<Light>().intensity;
        size_halo = 0.1f;

        halo = (Behaviour)GetComponent("Halo");


        timer = 5;
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            mat.color = new Color(color_Mat.r, color_Mat.g, color_Mat.b, color_Mat.a - (Time.deltaTime/2.0f));
            color_Mat = mat.color;

            intensity -= Time.deltaTime/0.4f;
            light.intensity = intensity;


            size_halo -= Time.deltaTime;
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

            if (timer <= -5)
            {
                DestroyImmediate(gameObject);

            }
        }

    }
}
