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

        // Use this for initialization
        void Start()
        {
            //STOP LOOKING AT THE PREFAB LOOK AT THE ACTUAL CHARACTER
            PlayerCube = GameObject.Find("SquishyCubeCharacter");
        }

        // Update is called once per frame
        void Update()
        {
            //test scaling
        }

        //spawns thing of increased size

        //spawn particle
        public void SpawnGrowthParticle(int whichcubeyo)
        {
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
