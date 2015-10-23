using UnityEngine;
using System.Collections;

public class Fluidra_Manager_Script : MonoBehaviour {



    GameObject spa_GO;
    GameObject spa_GO_2;

    float speed = 0;

	// Use this for initialization
	void Start ()
    {

        spa_GO = transform.FindChild("SM240_Ref").gameObject;
        spa_GO_2 = transform.FindChild("SM240_Ref (1)").gameObject;
        spa_GO_2.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F7))
        {

            StartCoroutine(ChangeSpa(0.2f));

        }

    }
    IEnumerator ChangeSpa(float delayTime)
    {
        GameObject spa;
        if (spa_GO.activeInHierarchy)
            spa = spa_GO;
        else
            spa = spa_GO_2;

        yield return new WaitForSeconds(delayTime); // start at time X

        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 2)
        {
            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed += 100.0f * Time.deltaTime;
            yield return 1; // wait for next frame
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
        while (Time.time - startTime <= 4)
        {
            spa.transform.Rotate(new Vector3(0, speed, 0));
            speed -= 100.0f * Time.deltaTime;
            yield return 1; // wait for next frame
        }

        yield return new WaitForEndOfFrame();

    }

}
