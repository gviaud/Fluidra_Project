/*
Viaud Guillaume 20/10/2015

ScreenShot de l'appli :
2 textures sont créées : 1 avec la cam 1 et une avec la cam 2
Ses textures sont envoyés à script "CreatePDF_Script"

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Capture_Script : MonoBehaviour {

    public Texture2D _texture;
    public Texture2D _texture2;
    public Texture2D _texture3;

    public GameObject _selectObject;

    public GameObject _cam1;
    public GameObject _cam2;

    //public GameObject _cam1Button;
	//public GameObject _cam2Button;
    //public GameObject _slider;
    public GameObject[] _backgroundTab;

    public GameObject _textVALIDATION;
    public GameObject _textMiseEnScene;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator CaptureC()
    {

        for (int i = 0; i < _backgroundTab.Length; i++)
        {
            _backgroundTab[i].SetActive(false);
        }

        _textMiseEnScene.transform.parent.gameObject.SetActive(true);

        //photo 1
        _cam1.SetActive(true);
        _cam2.SetActive(false);
        //_slider.SetActive(false);

        _cam1.transform.position = new Vector3(0, 6.1f, -14.45061f);
        _cam1.transform.eulerAngles = new Vector3(8.710641f, 0, 0);

        //_cam1Button.SetActive(false);
        //_cam2Button.SetActive(false);
        //_slider.SetActive(false);

        StartCoroutine(renderTex1());
        yield return new WaitForSeconds(0.75f);

        //photo 2

        _cam1.SetActive(false);
        _cam2.SetActive(true);

        _textMiseEnScene.GetComponent<Text>().text = "Photo 2";

        StartCoroutine(renderTex2());
        yield return new WaitForSeconds(0.75f);

        _textVALIDATION.SetActive(true);

        _cam1.SetActive(true);
        _cam2.SetActive(false);

        _textMiseEnScene.transform.parent.gameObject.SetActive(false);

    }

    public void Capture()
	{

        StartCoroutine(CaptureC());

    }


    IEnumerator renderTex1()
    {

        _texture = new Texture2D(Screen.width, Screen.height);
        yield return new WaitForEndOfFrame();
        _texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        _texture.Apply();

    }
    IEnumerator renderTex2()
    {

        _texture2 = new Texture2D(Screen.width, Screen.height);
        yield return new WaitForEndOfFrame();
        _texture2.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        _texture2.Apply();

    }
    IEnumerator renderTex3()
    {

        _texture3 = new Texture2D(Screen.width, Screen.height);
        yield return new WaitForEndOfFrame();
        _texture3.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        _texture3.Apply();
        _textVALIDATION.SetActive(true);
    }

}
