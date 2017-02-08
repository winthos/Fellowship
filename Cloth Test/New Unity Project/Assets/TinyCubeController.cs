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
        GameObject PlayerCube;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //spawns thing of increased size
        public void GetBigger()
        {
            //Vector3 currentScale = gameObject.GetComponent<Transform>().localScale;
            //gameObject.GetComponent<Transform>().localScale = currentScale * 2.0f;
        }
        //spawn particle
        public void SpawnGrowthParticle()
        {
            GameObject particle = (GameObject)Instantiate(ParticleToSpawn, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
            GameObject newCube = (GameObject)Instantiate(MediumCube, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
            PlayerCube.GetComponent<CubeController>().LittleCube = newCube;
            Destroy(gameObject);
        }
    }

}
