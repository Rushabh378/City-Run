using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> cityBlock;

        private Queue<GameObject> blocks = new();
        private Vector3 spawnPosition;
        private GameObject frontBlock = null;
        private System.Random random = new();

        private void Start()
        {
            LoopRoad.PassedArea += () =>LoopSequance();

            for(int i = 0; i < 5; i++)
            {
                int index = random.Next(cityBlock.Count);
                if (frontBlock == null)
                {
                    frontBlock = Instantiate(cityBlock[index], spawnPosition, Quaternion.identity);
                }
                else
                {
                    spawnPosition = Vector3.forward * (frontBlock.transform.position.z + 24);

                    frontBlock = Instantiate(cityBlock[index], spawnPosition, Quaternion.identity);
                }
                
                blocks.Enqueue(frontBlock);
            }
        }

        private void LoopSequance()
        {
            GameObject block = blocks.Dequeue();

            spawnPosition = Vector3.forward * (frontBlock.transform.position.z + 24);

            block.transform.position = spawnPosition;

            frontBlock = block;
            blocks.Enqueue(frontBlock);
        }
    }
}
