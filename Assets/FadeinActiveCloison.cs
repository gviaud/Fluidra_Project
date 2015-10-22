using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeinActiveCloison : MonoBehaviour {

   private CanvasGroup cg;

    // Use this for initialization
    void Start () {

      
    }
    void Awake() {
        cg = GetComponent<CanvasGroup>();
    }
	// Update is called once per frame
	void Update () {
       
    }
    void OnEnable()
    {
        StartCoroutine(DoFade());
    }
   IEnumerator DoFade()
    {
        cg.alpha = 0;
        while (cg.alpha <1)
        {
            cg.alpha += Time.deltaTime*5f;
            yield return null;
        }
        yield return null;
    }

}
