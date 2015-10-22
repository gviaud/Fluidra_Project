/*
Viaud Guillaume 20/10/2015

Reduction des effets visuels en fonctions des fps

*/
using UnityEngine;
using System.Collections;

public class BenchFPS_Script : MonoBehaviour {

    float timer;
    float deltaTime = 0.0f;

    MirrorReflection mirrorReflection;

    int allMask;
    int nbrFrame;
    float moyenneFPS;

    public GameObject lightManager;
    int etape;

    // Use this for initialization
    void Start ()
    {
        mirrorReflection = GameObject.Find("Plane").GetComponent<MirrorReflection>();
        timer = 5.0f;
        allMask = mirrorReflection.m_ReflectLayers;
        nbrFrame = 0;
        moyenneFPS = 0.0f;

        etape = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        moyenneFPS += fps;
        nbrFrame++;


        if (etape == 0)
        {
            if (timer <= 0)
            {

                moyenneFPS /= nbrFrame;
                //print("moyenneFPS : "+ moyenneFPS);

                if (moyenneFPS <= 15)
                {
                    Debug.Log("Reflet off");
                    mirrorReflection.m_ReflectLayers = (0 << 1) | (0 << 2) | (0 << 3) | (0 << 4) | (0 << 5) | (0 << 6) | (0 << 7) | (0 << 8) | (0 << 9);
                    //QualitySettings.antiAliasing = 0;
                    etape = 1;
                    timer = 5.0f;
                    moyenneFPS = 0;
                    nbrFrame = 0;
                }
                else
                {
                    timer = 5.0f;
                    moyenneFPS = 0;
                    nbrFrame = 0;
                }
            }
        }
        /*
        else if (etape == 1)
        {
            if (timer <= 0)
            {

                moyenneFPS /= nbrFrame;

                if (moyenneFPS <= 15)
                {
                    Debug.Log("Lumiere off");

                    for (int i = 0; i < lightManager.GetComponent<LightManager_Script>()._Light_Main_Tab.Length; i++)
                    {
                        if(lightManager.GetComponent<LightManager_Script>()._Light_Main_Tab[i] != null)
                            lightManager.GetComponent<LightManager_Script>()._Light_Main_Tab[i].GetComponent<Light>().cullingMask = 0 << 0;
                    }
                    for (int i = 0; i < lightManager.GetComponent<LightManager_Script>()._Light_Enseigne_Tab.Length; i++)
                    {
                        if (lightManager.GetComponent<LightManager_Script>()._Light_Enseigne_Tab[i] != null)
                            lightManager.GetComponent<LightManager_Script>()._Light_Enseigne_Tab[i].GetComponent<Light>().cullingMask = 0 << 0;
                    }
                    for (int i = 0; i < lightManager.GetComponent<LightManager_Script>()._Light_Left_Tab.Length; i++)
                    {
                        if (lightManager.GetComponent<LightManager_Script>()._Light_Left_Tab[i] != null)
                            lightManager.GetComponent<LightManager_Script>()._Light_Left_Tab[i].GetComponent<Light>().cullingMask = 0 << 0;
                    }
                    for (int i = 0; i < lightManager.GetComponent<LightManager_Script>()._Light_Reserve_Tab.Length; i++)
                    {
                        if (lightManager.GetComponent<LightManager_Script>()._Light_Reserve_Tab[i] != null)
                            lightManager.GetComponent<LightManager_Script>()._Light_Reserve_Tab[i].GetComponent<Light>().cullingMask = 0 << 0;
                    }
                    for (int i = 0; i < lightManager.GetComponent<LightManager_Script>()._Light_Right_Tab.Length; i++)
                    {
                        if (lightManager.GetComponent<LightManager_Script>()._Light_Right_Tab[i] != null)
                            lightManager.GetComponent<LightManager_Script>()._Light_Right_Tab[i].GetComponent<Light>().cullingMask = 0 << 0;
                    }
                    timer = 5.0f;
                    moyenneFPS = 0;
                    nbrFrame = 0;
                }
                else
                {
                    timer = 5.0f;
                    moyenneFPS = 0;
                    nbrFrame = 0;
                }
            }
        }*/
    }
}
