/*
Viaud Guillaume 20/10/2015

Pas encore utilisé, a revoir....

*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LibraryLoader : MonoBehaviour {

	const string assetbundleFolder = "http://www.pointcube.com/TestFileServer/Stand3/AssetBundles/";
	public GameObject _ObjectMenu;
	int _numMenuObj = 0;

	AssetBundle[] _bundles;
	int maxBundle;
    /*
	// Use this for initialization
	IEnumerator Start () 
	{
		maxBundle = 0;
		_bundles = new AssetBundle[10];
		string manifestABPath = assetbundleFolder + "AssetBundles";
			
		//load AssetbundleManifest assetbundle
		WWW wwwManifest = new WWW(manifestABPath);
		yield return wwwManifest;
		AssetBundle manifestbundle = wwwManifest.assetBundle;

		//load AssetBundleManifest object
		AssetBundleManifest manifest = manifestbundle.LoadAsset ("AssetBundleManifest") as AssetBundleManifest;
		manifestbundle.Unload (false);

		string[] bundleName_Tab = manifest.GetAllAssetBundles();

		for(int i = 0; i < bundleName_Tab.Length; i++)
		{

			//print (bundleName_Tab[i]);

			//Get dependant assetbundles
			string[] dependantAssetbundles = manifest.GetAllDependencies (bundleName_Tab[i]);

			//load dependant assetBundles
			AssetBundle[] assetBundles = new AssetBundle[dependantAssetbundles.Length];
			for(int j = 0; j < dependantAssetbundles.Length; j++)
			{
				string assetBundlePath = assetbundleFolder + dependantAssetbundles[j];

				//get the hash
				Hash128 hash = manifest.GetAssetBundleHash(dependantAssetbundles[j]);
				WWW www = WWW.LoadFromCacheOrDownload(assetBundlePath, hash);
				yield return www;
				assetBundles[j] = www.assetBundle;
			}

			//load object asset bundle
			WWW wwwObject = WWW.LoadFromCacheOrDownload(assetbundleFolder + bundleName_Tab[i], manifest.GetAssetBundleHash(bundleName_Tab[i]));
			yield return wwwObject;
			AssetBundle objectbundle = wwwObject.assetBundle;

			_bundles[maxBundle] = objectbundle;
			maxBundle ++;

			//load object
			string objectname = bundleName_Tab[i].Split('.')[0];
			GameObject objectPrefab = (GameObject)objectbundle.LoadAsset( objectname );
			Transform button = _ObjectMenu.transform.GetChild(_numMenuObj);
			button.GetComponent<Obj_Button>()._go = objectPrefab;
			GameObject newGameobject = GameObject.Instantiate(objectPrefab);

			//Initialisation object
			newGameobject.transform.position = new Vector3(0,objectPrefab.transform.localScale.y/2.0f,0);
			newGameobject.layer = 8;

			newGameobject.AddComponent<Object_Script>();
			newGameobject.name = objectname;

			if( newGameobject.GetComponent<InitialisationObject>()._menuName.Length > 0 )
			{
				newGameobject.GetComponent<Object_Script>()._menuNum = 0;
				for(int x =0; x < 0; x++)
				{
					newGameobject.GetComponent<Object_Script>()._menu[x] = GameObject.Find(newGameobject.GetComponent<InitialisationObject>()._menuName[x]);
				}
			}

			button.GetComponent<Image>().sprite = newGameobject.GetComponent<InitialisationObject>()._thumb;
			button.GetComponent<Obj_Button>().CreateButtonOnClick();

			_numMenuObj++;

			DestroyImmediate(newGameobject.gameObject);
		}
	
	}

	public void unload()
	{
		GameObject[] childTab = new GameObject[transform.childCount];
		for( int i = 0; i < childTab.Length; i++ )
			childTab[i] = transform.GetChild(i).gameObject;

		for( int i = 0; i < childTab.Length; i++ )
			DestroyImmediate( childTab[i].gameObject );

		for( int i =0; i < maxBundle; i++ )
		{
			_bundles[i].Unload(true);
		}

	}*/

}
