using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{


    public class BuddyVictoryToggle : MonoBehaviour
    {
        public bool IamHere = false;

        public GameObject PlayerVictory;
        public GameObject MyLight;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider super)
        {
            print("something is touching me");
           if (super.name == "FullCube(Clone)")
            {
                print("buddy cube is here");
                IamHere = true;
                MyLight.GetComponent<Light>().enabled = true;
                //super.GetComponent<CubeController>().VictoryJump = true;
            }
        }

        void OnTriggerExit(Collider super)
        {
            if (super.name == "FullCube(Clone)")
            {
                IamHere = false;
                MyLight.GetComponent<Light>().enabled = false;
            }
               
        }
    }
}
