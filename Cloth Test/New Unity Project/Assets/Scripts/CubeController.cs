using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField]
        public GameObject LittleCube;

        [SerializeField]
        GameObject StartFollowingMe;

        [SerializeField]
        GameObject StopFollowingMe;

        private bool IsItEnabled = false;

        private float OriginalJumpPower = 0.0f;

        private float FollowTimer = 0.0f;

        private float StopFollowTimer = 0.0f;

        public float SpriteTimerAmount = 2.0f;

        public bool StartTheMirror = false;

        private bool StartShowingSprites = false;

        ThirdPersonCharacter cc;

        public AudioSource JumpSound;
        public AudioSource LandSound;
        public AudioSource YaySound;

        public AudioSource StartFollowSound;
        public AudioSource StopFollowSound;

        public AudioClip atesound;

        public AudioClip[] footsteps;

        private bool amJumping = false;

        public bool VictoryJump = false;
        private float timer = 0f;
        private bool dothisonce = false;
        // Use this for initialization
        void Start()
        {
            OriginalJumpPower = gameObject.GetComponent<ThirdPersonCharacter>().GetJumpSpeed();
            FollowTimer = SpriteTimerAmount;
            StopFollowTimer = SpriteTimerAmount;

            cc = GetComponent<ThirdPersonCharacter>();
        }

        public void PlayIGotFed()
        {
            GetComponent<AudioSource>().PlayOneShot(atesound);
        }

        // Update is called once per frame
        void Update()
        {
            if(VictoryJump == true)
            {
                if(dothisonce == false)
                {
                    print("yaaaay");
                    YaySound.GetComponent<AudioSource>().Play();
                    dothisonce = true;
                }

                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                LittleCube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                timer += Time.deltaTime;
                if(timer >= 2.0f)
                {
                    gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(4.0f);
                    gameObject.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, true);
                    gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(OriginalJumpPower);
                    timer = 0f;
                }

            }
            
            if (cc.AmIGrounded() == true && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d") ) && GetComponent<AudioSource>().isPlaying == false)
            {

                //GetComponent<AudioSource>().Play();
                GetComponent<AudioSource>().PlayOneShot(footsteps[Random.Range(0, 2)]);
                if(IsItEnabled == true)
                LittleCube.GetComponent<AudioSource>().PlayOneShot(footsteps[Random.Range(0, 2)]);
            }

            if (cc.AmIGrounded() == false || (Input.GetKey("w")== false && Input.GetKey("s") == false && Input.GetKey("d") == false && Input.GetKey("a") == false))
            {
                GetComponent<AudioSource>().Pause();
            }

            //play jump sound
            if(Input.GetKeyDown(KeyCode.Space))
            {
                JumpSound.GetComponent<AudioSource>().Play();
                amJumping = true;
            }

            if(amJumping == true && cc.AmIGrounded() == true)
            {
                amJumping = false;
                LandSound.GetComponent<AudioSource>().Play();
            }



            if(StartTheMirror == false)
            {
                return;
            }

            //stop following
            if (Input.GetKeyDown(KeyCode.E) && IsItEnabled == true && gameObject.GetComponent<ThirdPersonCharacter>().AmIGrounded() == true)
            {
                StopFollowSound.GetComponent<AudioSource>().Play();
                StartShowingSprites = true;
                print("switch off");
                LittleCube.GetComponent<ThirdPersonUserControl>().enabled = false;
                IsItEnabled = false;
                //this stops the little cube from moving forward if a movement button is held down when E is pressed
               LittleCube.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(3.0f);
                gameObject.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, true);
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(OriginalJumpPower);
                //play squish and maybe have an emote here
            }

            //start following
            else if (Input.GetKeyDown(KeyCode.E) && IsItEnabled == false)
            {
                StartFollowSound.GetComponent<AudioSource>().Play();
                StartShowingSprites = true;
                print("switching on");
                LittleCube.GetComponent<ThirdPersonUserControl>().enabled = true;
                LittleCube.GetComponent<TinyCubeController>().PlayerMetMe = true;
                IsItEnabled = true;
                //this lets the little cube move again cause reasons
                LittleCube.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(4.0f);
                gameObject.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, true);
                gameObject.GetComponent<ThirdPersonCharacter>().SetJumpSpeed(OriginalJumpPower);
                //play squish then maybe have an emote here as well
            }

            if (IsItEnabled == false && StartShowingSprites == true)
            {
               //stop following me sprite
               if(StopFollowTimer > 0.0f)
                {
                    StartFollowingMe.GetComponent<SpriteRenderer>().enabled = false;
                    FollowTimer = SpriteTimerAmount;
                    StopFollowTimer -= Time.deltaTime;
                    StopFollowingMe.GetComponent<SpriteRenderer>().enabled = true;
                }
               if(StopFollowTimer <= 0.0f)
                {
                    StopFollowingMe.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            if (IsItEnabled == true & StartShowingSprites == true)
            {
                //start following me sprite
                if (FollowTimer > 0.0f)
                {
                    StopFollowingMe.GetComponent<SpriteRenderer>().enabled = false;
                    StopFollowTimer = SpriteTimerAmount;
                    FollowTimer -= Time.deltaTime;
                    StartFollowingMe.GetComponent<SpriteRenderer>().enabled = true;
                }
                if (FollowTimer <= 0.0f)
                {
                    StartFollowingMe.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}
