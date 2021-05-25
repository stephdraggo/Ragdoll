using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ragdoll
{
    public class GameManager : MonoBehaviour
    {
        public static int Points;
        [SerializeField] private float timer = 10;

        [SerializeField] private Text textDisplay;

        private string sceneName;

        private void Start()
        {
            timer++;
            Points = 0;
            sceneName = SceneManager.GetActiveScene().name;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            textDisplay.text = $"{Points} points\n{(int) timer} seconds left...";
        }

        //we want to see the text tick down to 0 before actually ending the level
        private void LateUpdate()
        {
            if (timer < 0)
                SceneManager.LoadScene(sceneName);
        }
    }
}