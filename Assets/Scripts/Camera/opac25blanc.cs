using UnityEngine;
using System.Collections;

public class opac25blanc : MonoBehaviour
{
    public GameObject cam2;
    public GameObject objetAtransparenter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.activeInHierarchy)
        {
            //First Material
            objetAtransparenter.GetComponent<Renderer>().material.SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().material.renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().material.color = new Color(0.58f, 0.58f, 0.58f, 0.1f);
          
        }
        else
        {

            objetAtransparenter.GetComponent<Renderer>().material.SetFloat("_Mode", 0);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().material.renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().material.color = new Color(0.58f, 0.58f, 0.58f, 1);
        }
    }
}
