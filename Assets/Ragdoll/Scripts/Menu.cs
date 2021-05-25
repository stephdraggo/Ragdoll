using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

namespace Ragdoll
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel, resultsPanel;
        [SerializeField] private TMP_Text resultsDisplay;

        private string sceneName;

        private void Start()
        {
            GameManager.Instance.menu = this;
            sceneName = SceneManager.GetActiveScene().name;
        }

        public void Play()
        {
            Time.timeScale = 1;
            menuPanel.SetActive(false);
        }

        public void Retry()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void End()
        {
            Time.timeScale = 0;
            resultsDisplay.text = $"You Scored {GameManager.Instance.points}!\nBut can you do better?";
            resultsPanel.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}