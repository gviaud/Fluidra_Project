using UnityEngine;
using System.Collections;

public class Opac25 : MonoBehaviour {
    public GameObject cam2;
    public GameObject objetAtransparenter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(cam2.activeInHierarchy)
        {//first material
            objetAtransparenter.GetComponent<Renderer>().material.SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().material.renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().material.color= new Color(0.17f, 0.17f, 0.17f, 0.1f);
            //2nd Material
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[1].color = new Color(1, 1, 1, 0.1f);
            //3Rrd material
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[2].color = new Color(1, 1, 1, 0.1f);
            //4th material
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[3].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[3].color = new Color(0.23f, 0.23f, 0.23f, 0.1f);
            //5th material
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[4].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[4].color = new Color(0.59f, 0.59f, 0.59f, 0.1f);
        }
    else
        {
            //First Material
            objetAtransparenter.GetComponent<Renderer>().material.SetFloat("_Mode", 0);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().material.renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().material.color = new Color(0.17f,0.17f,0.17f, 1);
            //2nd Material
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[1].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[1].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[1].color = new Color(1, 1, 1, 1);
            //3Rrd material
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[2].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[2].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[2].color = new Color(1, 1, 1, 1);
            //4th material
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[3].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[3].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[3].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[3].color = new Color(0.23f, 0.23f, 0.23f,1);
            //5th material
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetFloat("_Mode", 3);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objetAtransparenter.GetComponent<Renderer>().materials[4].SetInt("_ZWrite", 0);
            objetAtransparenter.GetComponent<Renderer>().materials[4].DisableKeyword("_ALPHATEST_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].EnableKeyword("_ALPHABLEND_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objetAtransparenter.GetComponent<Renderer>().materials[4].renderQueue = 3000;
            objetAtransparenter.GetComponent<Renderer>().materials[4].color = new Color(0.59f, 0.59f, 0.59f, 1);
        }
	}
}
