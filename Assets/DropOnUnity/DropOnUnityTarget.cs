using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DropOnUnityTarget : MonoBehaviour {

	Select_Object_Script selectScript;

    public GameObject menuSide;

    DropOnUnityCtrl _dropOnUnityCtrl;

	public bool growOnExternalDragOver = true;

	private Vector3 dftScale;
	private bool isDraging;
	void Start() {
		isDraging = false;
		dftScale = transform.localScale;

		selectScript = GameObject.Find ("SceneManager").GetComponent<Select_Object_Script> ();

	}
	void Update(){
		if(!isDraging){
			dftScale = transform.localScale;
		}
	}
	public void OnExternalDragOver(Vector3 cursorPosition) {
		isDraging = true;
		transform.localScale = dftScale*1.4f;
	}
	public void OnExternalDragCancel() {
		transform.localScale = dftScale;
		isDraging = false;
	
	}
	void Simplify(int[] numbers)
	{
		int gcd = GCD(numbers[0],numbers[1]);
		for (int i = 0; i < numbers.Length; i++)
			numbers[i] /= gcd;
	}
	int GCD(int a, int b)
	{
		while (b > 0)
		{
			int rem = a % b;
			a = b;
			b = rem;
		}
		return a;
	}

	public void OnExternalDragEnd(Texture2D aTexture) {

		if(selectScript == null)
		{
			selectScript = GameObject.Find ("SceneManager").GetComponent<Select_Object_Script> ();
		}

		selectScript.SelectObjectViaMenu(gameObject);
		selectScript.DeselectMenu ();


		if (selectScript._select_GO.name.StartsWith("Decal"))
		{
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.WhiteTextMenu(selectScript.MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
			selectScript.SideMenu.SetActive(true);
			selectScript.SideMenu.transform.GetChild(2).gameObject.SetActive(true);

			selectScript.SecondMenu.SetActive(true);
			selectScript.SecondMenu.transform.GetChild(0).gameObject.SetActive(true);
			
			selectScript.PrixDetail.SetActive(true);
			selectScript.OK.SetActive(true);
			selectScript.Surface.SetActive(false);
		}
		else if (selectScript._select_GO.name.StartsWith("Enseigne"))
		{
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.WhiteTextMenu(selectScript.MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
			selectScript._SceneManager_Script.GriserTextMenu(selectScript.MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
			selectScript.SecondMenu.SetActive(true);
			selectScript.SecondMenu.transform.GetChild(2).gameObject.SetActive(true);
			selectScript.SideMenu.SetActive(true);
			selectScript.SideMenu.transform.GetChild(5).gameObject.SetActive(true);

			selectScript.PrixDetail.SetActive(true);
			selectScript.OK.SetActive(true);
			selectScript.Surface.SetActive(false);
		}

        GetComponent<Decal_Script>().ResetPosition();
        if (name.StartsWith("Decal"))
            GetComponent<Decal_Script>()._scale = 3.0f;
        else
            GetComponent<Decal_Script>()._scale = 1.0f;
        GetComponent<Decal_Script>()._rotation = 180.0f;

        if (name.StartsWith("Decal"))
            menuSide.transform.GetChild(2).GetComponent<Slider>().value = 3.0f;
        else
            menuSide.transform.GetChild(2).GetComponent<Slider>().value = 1.0f;

        menuSide.transform.GetChild(3).GetComponent<Slider>().value = 180;

        Decal_Script decal_Script = GetComponent<Decal_Script>();

		int[] tab = new int[2];
		print (""+aTexture.width+ "   "+aTexture.height);
		tab[0] = aTexture.width;
		tab[1] = aTexture.height;
		Simplify(tab);
		float ratio = (float)tab[0]/(float)tab[1];
		print (""+ratio);

		decal_Script._ratioX = ratio;
		decal_Script._ratioY = 1;
        if (name.StartsWith("Decal"))
        {
            menuSide.transform.GetChild(2).GetComponent<Slider>().value = 3.0f;
            transform.localScale = new Vector3(ratio * 3.0f, 3.0f, 1f);
        }
        else
        {
            menuSide.transform.GetChild(2).GetComponent<Slider>().value = 1.0f;
            transform.localScale = new Vector3(ratio, 1.0f, 1f);
        }

		gameObject.GetComponent<Renderer>().material.mainTexture = aTexture;
		// what we receive is a newly instatiated texture, 
		// you may want to clean up the previous texture
		//transform.localScale = dftScale;
		isDraging = false;
		//_dropOnUnityCtrl = GameObject.Find ("DropOnUnity").GetComponent<DropOnUnityCtrl> ();
		//_dropOnUnityCtrl._chargementTXT.gameObject.SetActive (false);

		selectScript.ActivAideDeplacerVisuel ();
		selectScript.AideMultiFace.SetActive (false);
		selectScript.AideMultiFace2.SetActive (false);
		selectScript.AideGlisserDeposer.SetActive (false);
	}
	public void OnExternalDragEnd(string text) {
		Debug.Log("text received. Length: "+text.Length);
	}
	public void OnExternalDragEnd(byte[] bytes) {
		Debug.Log(bytes.Length+" bytes received");
	}


	public void OnExternalDragFilesToExpect(int nrOfFilesToExpect) {
		// Nr of files dragged on Unity
		// this is send before the first files is processed

		_dropOnUnityCtrl = GameObject.Find ("DropOnUnity").GetComponent<DropOnUnityCtrl> ();

		_dropOnUnityCtrl._chargementTXT.gameObject.SetActive (true);
		_dropOnUnityCtrl._chargementTXT.transform.GetChild(0).GetComponent<Text>().text = "Chargement...";

	}
	public void OnExternalDragFileName(string fileName) {
		// filename (without path) of the file that is about to be processed
	}
	public void OnExternalDragFileExtension(string lowercaseFileExtension) {
		// fileextension (without dot and in lowercase) of the file that is about to be processed
	}
	public void OnExternalDragAllFilesReceived() {
		// this is send after the last file is processed
	}

}
