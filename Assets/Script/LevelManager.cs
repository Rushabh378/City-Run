using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class LevelManager : GenericSingleton<LevelManager>
    {
        [SerializeField] private GameObject cityBlock;

        private Queue<GameObject> blocks = new();
        private Vector3 spawnPosition;
        private Vector3 frontPosition;
        private GameObject frontBlock = null;

        private void Start()
        {
            LoopRoad.PassedArea += () =>LoopSequance();

            for(int i = 0; i < 5; i++)
            {
                if(frontBlock == null)
                {
                    frontBlock = Instantiate(cityBlock, spawnPosition, Quaternion.identity);
                }
                else
                {
                    frontPosition = frontBlock.transform.position;
                    spawnPosition = new Vector3(frontPosition.x, frontPosition.y, frontPosition.z + 24);

                    frontBlock = Instantiate(cityBlock, spawnPosition, Quaternion.identity);
                }
                
                blocks.Enqueue(frontBlock);
            }
        }

        private void LoopSequance()
        {
            GameObject block = blocks.Dequeue();

            frontPosition = frontBlock.transform.position;
            spawnPosition = new Vector3(frontPosition.x, frontPosition.y, frontPosition.z + 24);

            block.transform.position = spawnPosition;

            blocks.Enqueue(block);
            frontBlock = block;
        }
    }
}
