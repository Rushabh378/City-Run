using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> cityBlock;
        [SerializeField] private GameObject pauseMenu;

        private Queue<GameObject> blocks = new();
        private Vector3 spawnPosition;
        private GameObject frontBlock = null;
        private System.Random random = new();
        private bool isGamePaused;

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

            PauseGame();
            pauseMenu.SetActive(false);// waiting for player to start.
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isGamePaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
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

        public void PauseGame()
        {
            Time.timeScale = 0;
            isGamePaused = true;
            pauseMenu.SetActive(true);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            isGamePaused = false;
            pauseMenu.SetActive(false);
        }
        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }
    }
}
