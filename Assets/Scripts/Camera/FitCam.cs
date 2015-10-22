/*
Viaud Guillaume 20/10/2015

Agrandissement, Rapetissement de la vision de la cam en fonction de la taille de la scene

*/
using UnityEngine;
using System.Collections;

public class FitCam : MonoBehaviour {

    SceneManager_Script sceneManager;
    Camera cam;
    float lastfieldOfView;

    // Use this for initialization
    void Start () {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager_Script>();
        cam = GetComponent<Camera>();
        lastfieldOfView = cam.fieldOfView;
    }

	// Update is called once per frame
	void Update () {

        int fieldOfView = 0;
        int add = 0;

        float y = 7.52f ;

        if (sceneManager._Enseigne.activeInHierarchy)
        {

            y = 9.0f;
            if (sceneManager._isCarre)
            {
                if (sceneManager._enseigneLongueur == 2)
                    add = 14;
                else if (sceneManager._enseigneLongueur == 3)
                    add = 18;
                else if (sceneManager._enseigneLongueur == 4)
                    add = 22;
                else if (sceneManager._enseigneLongueur == 5)
                    add = 26;
            }               
            else
                add = 10;
        }
        else
            add = 0;




        if (sceneManager._largeur == 3)
        {
            if (sceneManager._longueur == 4)
            {
                fieldOfView = 44;
            }
            else if (sceneManager._longueur == 5)
            {
                fieldOfView = 44;
            }
            else if (sceneManager._longueur == 6)
            {
                fieldOfView = 44;
            }
            else if (sceneManager._longueur == 7)
            {
                fieldOfView = 50;
            }
            else if (sceneManager._longueur == 8)
            {
                fieldOfView = 56;
            }
            else if (sceneManager._longueur == 9)
            {
                fieldOfView = 63;
            }
            else if (sceneManager._longueur == 10)
            {
                fieldOfView = 68;
            }

            ///////////////////////////////////
            if (sceneManager._Enseigne.activeInHierarchy)
            {

                if (!sceneManager._isCarre)
                {
                        
                   
                        if (sceneManager._longueur == 6)
                        {
                            add = 10;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            add = 4;
                        }
                        else if (sceneManager._longueur >= 8)
                        {
                            add = 0;
                        }

    

                }
                else if (sceneManager._isCarre)
                {
                    if (sceneManager._enseigneLongueur == 2)
                    {
                        if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 9)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 10)
                        {
                            fieldOfView = 63; add = 0;
                        }

                    }
                    else if (sceneManager._enseigneLongueur == 3)
                    {
                        if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 9)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 10)
                        {
                            fieldOfView = 63; add = 0;
                        }

                    }
                    else if (sceneManager._enseigneLongueur == 4)
                    {
                        if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 9)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 10)
                        {
                            fieldOfView = 63; add = 0;
                        }

                    }
                    else if (sceneManager._enseigneLongueur == 5)
                    {
                        if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 54; add = 0;
                        }
                        else if (sceneManager._longueur == 9)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 10)
                        {
                            fieldOfView = 63; add = 0;
                        }
                    }

                }
              
            }

        }
        else if (sceneManager._largeur == 4)
        {
            if (sceneManager._longueur == 3)
            {
                fieldOfView = 49;
            }
            else if (sceneManager._longueur == 4)
            {
                fieldOfView = 49;
            }
            else if (sceneManager._longueur == 5)
            {
                fieldOfView = 49;
            }
            else if (sceneManager._longueur == 6)
            {
                fieldOfView = 49;
            }
            else if (sceneManager._longueur == 7)
            {
                fieldOfView = 55;
            }
            else if (sceneManager._longueur == 8)
            {
                fieldOfView = 61;
            }



            ///////////////////////////////////
            if (sceneManager._Enseigne.activeInHierarchy)
            {

                if (!sceneManager._isCarre)
                {


                    if (sceneManager._longueur <= 7)
                    {
                        add = 0;
                        fieldOfView = 56;
                    }
                    else if (sceneManager._longueur == 8)
                    {
                        add = 0;
                        fieldOfView = 61;
                    }
                 

                }
                else if (sceneManager._isCarre)
                {
                    if (sceneManager._enseigneLongueur == 2)
                    {
                        if (sceneManager._longueur == 3)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 59; add = 0;
                        }



                    }
                    else if (sceneManager._enseigneLongueur == 3)
                    {
                        if (sceneManager._longueur == 3)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 59; add = 0;
                        }

                    }
                    else if (sceneManager._enseigneLongueur == 4)
                    {
                        if (sceneManager._longueur == 3)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 59; add = 0;
                        }

                    }
                    else if (sceneManager._enseigneLongueur == 5)
                    {
                        if (sceneManager._longueur == 3)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 4)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 5)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 6)
                        {
                            fieldOfView = 57; add = 0;
                        }
                        else if (sceneManager._longueur == 7)
                        {
                            fieldOfView = 58; add = 0;
                        }
                        else if (sceneManager._longueur == 8)
                        {
                            fieldOfView = 59; add = 0;
                        }

                    }
                  
                       
                }
             
            }


        }
        else if (sceneManager._largeur == 5)
        {
            if (sceneManager._longueur == 3)
            {
                fieldOfView = 54;
            }
            else if (sceneManager._longueur == 4)
            {
                fieldOfView = 54;
            }
            else if (sceneManager._longueur == 5)
            {
                fieldOfView = 54;
            }
            else if (sceneManager._longueur == 6)
            {
                fieldOfView = 54;
            }
            else if (sceneManager._longueur == 7)
            {
                fieldOfView = 59;
            }

            ///////////////////////////////////
            if (sceneManager._Enseigne.activeInHierarchy)
            {

                if (!sceneManager._isCarre)
                {

                    add = 0;
                    fieldOfView = 60;
                  
                }
                else if (sceneManager._isCarre)
                {
                    if (sceneManager._longueur == 3)
                    {
                        fieldOfView = 63; add = 0;
                    }
                    else if (sceneManager._longueur == 4)
                    {
                        fieldOfView = 63; add = 0;
                    }
                    else if (sceneManager._longueur == 5)
                    {
                        fieldOfView = 63; add = 0;
                    }
                    else if (sceneManager._longueur == 6)
                    {
                        fieldOfView = 63; add = 0;
                    }
                    else if (sceneManager._longueur == 7)
                    {
                        fieldOfView = 63; add = 0;
                    }

                }
                
            }

        }

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, (float)fieldOfView + (float)add, 0.1f);

        Vector3 vect = new Vector3(cam.transform.position.x, y, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, vect,0.1f);
        
    }
}
