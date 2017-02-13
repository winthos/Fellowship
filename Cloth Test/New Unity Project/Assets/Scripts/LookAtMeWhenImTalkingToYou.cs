using UnityEngine;
using System.Collections;

public class LookAtMeWhenImTalkingToYou : MonoBehaviour {

    public Transform target;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Main Camera").GetComponent<Transform>();
	}


    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target 
        transform.LookAt(target);
    }
}
