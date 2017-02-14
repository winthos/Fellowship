using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class VictoryToggle : MonoBehaviour
    {
        public bool IamHere = false;

        public GameObject BuddyVictory;
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
            MyLight.GetComponent<Light>().enabled = true;
            IamHere = true;
            if (super.name == "SquishyCubeCharacter" && BuddyVictory.GetComponent<BuddyVictoryToggle>().IamHere == true)
            {
                MyLight.GetComponent<Light>().enabled = true;
                super.GetComponent<CubeController>().VictoryJump = true;
            }
        }

        void OnTriggerExit(Collider super)
        {
            if (super.name == "SquishyCubeCharacter")
            {
                IamHere = false;
                MyLight.GetComponent<Light>().enabled = false;
            }
        }
    }
}
