using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class TinyCubeController : MonoBehaviour
    {

        [SerializeField]
        GameObject ParticleToSpawn;

        [SerializeField]
        GameObject MediumCube;

        [SerializeField]
        GameObject LargeCube;

        [SerializeField]
        GameObject AlmostLargestCube;

        [SerializeField]
        GameObject FullCube;

        [SerializeField]
        GameObject PlayerCube;

        public bool Idle = true;

        public bool PlayerMetMe = false;

        public AudioClip[] footsteps;

        public GameObject FaceSprite;

        public Sprite SadFace;
        public Sprite HappyFace;
        public Sprite HomeFace;
        public Sprite HungryFace;

        private bool dontchangesprites = false;
        // Use this for initialization
        void Start()
        {
            //STOP LOOKING AT THE PREFAB LOOK AT THE ACTUAL CHARACTER
            PlayerCube = GameObject.Find("SquishyCubeCharacter");
        }

        void OnTriggerEnter(Collider super)
        {
            if (super.tag == "steam")
            {
                FaceSprite.GetComponent<SpriteRenderer>().sprite = SadFace;
                dontchangesprites = true;
            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag == "steam")
            {
              //  FaceSprite.GetComponent<SpriteRenderer>().sprite = Happy;
                dontchangesprites = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(PlayerMetMe == false)
            {
                if (gameObject.name == "TinyCube")
                    FaceSprite.GetComponent<SpriteRenderer>().sprite = SadFace;

                else
                {
                    if(gameObject.name != "FullCube(Clone)")
                    {
                        FaceSprite.GetComponent<SpriteRenderer>().sprite = HappyFace;
                    }

                    if(gameObject.name =="FullCube(Clone)")
                    {
                        FaceSprite.GetComponent<SpriteRenderer>().sprite = HomeFace;
                    }
                }
            }

            //following player so i'm happy
            if(Idle == true && PlayerMetMe == true && dontchangesprites == false)
            {
                GetComponent<AudioSource>().Play();
                //if i'm not max sized, be happy
                if(gameObject.name != "FullCube(Clone)")
                FaceSprite.GetComponent<SpriteRenderer>().sprite = HappyFace;

                //if i am full then go home face
                if(gameObject.name == "FullCube(Clone)")
                {
                    FaceSprite.GetComponent<SpriteRenderer>().sprite = HomeFace;
                }

            }

            if(gameObject.GetComponent<Rigidbody>().isKinematic == false)
            {
                Idle = true;
            }

            //idle stand still, be sad and or hungry
            if (gameObject.GetComponent<Rigidbody>().isKinematic == true && dontchangesprites == false)
            {
                print("SHouldBe Hungry");
                if(PlayerMetMe == true)
                FaceSprite.GetComponent<SpriteRenderer>().sprite = HungryFace;
                Idle = false;
            }
        }

        //spawns thing of increased size

        //spawn particle
        public void SpawnGrowthParticle(int whichcubeyo)
        {
            PlayerCube.GetComponent<CubeController>().PlayIGotFed();
            //spawn the particle 
            GameObject particle = (GameObject)Instantiate(ParticleToSpawn, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);

            if(whichcubeyo == 1)
            {
                //check what I am and spawn the appropriate next biggest cube
                GameObject newCube = (GameObject)Instantiate(MediumCube, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                //reset the playercube tether
                PlayerCube.GetComponent<CubeController>().LittleCube = newCube;
            }

            if (whichcubeyo == 2)
            {
                //check what I am and spawn the appropriate next biggest cube
                GameObject newCube = (GameObject)Instantiate(LargeCube, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                //reset the playercube tether
                PlayerCube.GetComponent<CubeController>().LittleCube = newCube;
            }

            if (whichcubeyo == 3)
            {
                //check what I am and spawn the appropriate next biggest cube
                GameObject newCube = (GameObject)Instantiate(AlmostLargestCube, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                //reset the playercube tether
                PlayerCube.GetComponent<CubeController>().LittleCube = newCube;
            }

            if (whichcubeyo == 4)
            {
                //check what I am and spawn the appropriate next biggest cube
                GameObject newCube = (GameObject)Instantiate(FullCube, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                //reset the playercube tether
                PlayerCube.GetComponent<CubeController>().LittleCube = newCube;
            }

            Destroy(gameObject);
        }
    }

}
