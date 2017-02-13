using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class ToggleStart : MonoBehaviour
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
                super.GetComponent<CubeController>().StartTheMirror = true;
            }
        }
    }
}

