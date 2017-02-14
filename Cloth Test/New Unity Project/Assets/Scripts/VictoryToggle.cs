using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class VictoryToggle : MonoBehaviour
    {
        public bool IamHere = false;

        public GameObject BuddyVictory;

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
            IamHere = true;
            if (super.name == "SquishyCubeCharacter" && BuddyVictory.GetComponent<BuddyVictoryToggle>().IamHere == true)
            {
                super.GetComponent<CubeController>().VictoryJump = true;
            }
        }

        void OnTriggerExit(Collider super)
        {
            IamHere = false;
        }
    }
}
