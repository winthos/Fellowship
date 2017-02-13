using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class VictoryToggle : MonoBehaviour
    {

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
            if (super.name == "SquishyCubeCharacter")
            {
                super.GetComponent<CubeController>().VictoryJump = true;
            }
        }
    }
}
