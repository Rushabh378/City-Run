using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool isGamePaused;

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
