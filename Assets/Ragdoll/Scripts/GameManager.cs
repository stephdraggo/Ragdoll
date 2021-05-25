using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ragdoll
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int points;
        public float timer = 10;

        [SerializeField] private Text textDisplay;


        public Menu menu;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Time.timeScale = 0;
            timer++;
            points = 0;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            textDisplay.text = $"{points} points\n{(int) timer} seconds left...";
        }

        //we want to see the text tick down to 0 before actually ending the level
        private void LateUpdate()
        {
            if (timer < 0)
                menu.End();
        }
    }
}