using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField]
        GameObject LittleCube;

        private bool IsItEnabled = true;

        private float OriginalJumpPower = 0.0f;

        // Use this for initialization
        void Start()
        {
            OriginalJumpPower = gameObject.GetComponent<ThirdPersonCharacter>().GetJumpSpeed();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && IsItEnabled == true )
            {
                print("switch off");
                LittleCube.GetComponent<ThirdPersonUserControl>().enabled = false;
                IsItEnabled = false;
                //this stops the little cube from moving forward if a movement button is held down when E is pressed
                LittleCube.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(3.0f);
                gameObject.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, true);
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(6.0f);

                //play squish and maybe have an emote here
            }

            else if (Input.GetKeyDown(KeyCode.E) && IsItEnabled == false)
            {
                print("switching on");
                LittleCube.GetComponent<ThirdPersonUserControl>().enabled = true;
                IsItEnabled = true;
                //this lets the little cube move again cause reasons
                LittleCube.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(4.0f);
                gameObject.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, true);
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(6.0f);
                //play squish then maybe have an emote here as well
            }
        }
    }
}
