using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SteamRoller : MonoBehaviour
{
    [SerializeField]
    Camera maincamera;

    [SerializeField]
    Material HurtColor;

    [SerializeField]
    float howlong = 3.0f;

    //private GameObject[] whattouchedme;

    private bool DidIjustTouchSteam = false;
    private float timer = 0f;

	// Use this for initialization
	void Start ()
    {
        maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	   /* if(DidIjustTouchSteam == true)
        {
            timer += Time.deltaTime;

            if(timer >= howlong)
            {
             //   whattouchedme[0].GetComponent<Renderer>().material = NormalColor;
               // gameObject.GetComponent<Renderer>().material = NormalColor;
                timer = 0f;
                DidIjustTouchSteam = false;
                maincamera.GetComponent<SepiaTone>().enabled = false;
                maincamera.GetComponent<MotionBlur>().enabled = false;
            }
       
        }*/
	}

    
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Squishy Cube")
        {
            print("YES YES YES");
            //col.gameObject.GetComponent<Renderer>().material = HurtColor;
            //     whattouchedme[0] = col.gameObject;
            maincamera.GetComponent<SepiaTone>().enabled = true;
            maincamera.GetComponent<MotionBlur>().enabled = true;
            DidIjustTouchSteam = true;
        }

    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.name == "Squishy Cube")
        {
           // print("YES YES YES");
            //col.gameObject.GetComponent<Renderer>().material = HurtColor;
            //     whattouchedme[0] = col.gameObject;
            maincamera.GetComponent<SepiaTone>().enabled = false;
            maincamera.GetComponent<MotionBlur>().enabled = false;
            DidIjustTouchSteam = true;
        }
    }

}
