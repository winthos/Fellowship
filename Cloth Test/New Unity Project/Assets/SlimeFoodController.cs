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
                //  GameObject particle = (GameObject) Instantiate(ParticleToSpawn, gameObject.transform);
                collide.gameObject.GetComponent<TinyCubeController>().SpawnGrowthParticle();
                collide.gameObject.GetComponent<TinyCubeController>().GetBigger();
                Destroy(gameObject);

            }
        }
    }
}
