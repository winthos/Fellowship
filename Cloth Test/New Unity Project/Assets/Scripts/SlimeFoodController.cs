using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{


    public class SlimeFoodController : MonoBehaviour
    {



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collide)
        {
            if (collide.gameObject.name == "TinyCube")
            {
                print("spawning medium cube");
                //  GameObject particle = (GameObject) Instantiate(ParticleToSpawn, gameObject.transform);
                collide.gameObject.GetComponent<TinyCubeController>().SpawnGrowthParticle(1);
                Destroy(gameObject);
            }

            if (collide.gameObject.name == "MediumCube(Clone)")
            {
                print("Spawning large cube");
                //  GameObject particle = (GameObject) Instantiate(ParticleToSpawn, gameObject.transform);
                collide.gameObject.GetComponent<TinyCubeController>().SpawnGrowthParticle(2);
                Destroy(gameObject);
            }

            if (collide.gameObject.name == "LargeCube(Clone)")
            {
                print("Spawning AlmostLargestCube cube");
                //  GameObject particle = (GameObject) Instantiate(ParticleToSpawn, gameObject.transform);
                collide.gameObject.GetComponent<TinyCubeController>().SpawnGrowthParticle(3);
                Destroy(gameObject);
            }

            if (collide.gameObject.name == "AlmostLargestCube(Clone)")
            {
                print("Spawning Full cube");
                //  GameObject particle = (GameObject) Instantiate(ParticleToSpawn, gameObject.transform);
                collide.gameObject.GetComponent<TinyCubeController>().SpawnGrowthParticle(4);
                Destroy(gameObject);
            }
        }
    }
}
