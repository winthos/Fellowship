using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{


    public class BuddyVictoryToggle : MonoBehaviour
    {
        public bool IamHere = false;

        public GameObject PlayerVictory;

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
            
           if (super.name == "FullCube(Clone)")
            {
                
                IamHere = true;
                //super.GetComponent<CubeController>().VictoryJump = true;
            }
        }

        void OnTriggerExit(Collider super)
        {
            IamHere = false;
        }
    }
}
