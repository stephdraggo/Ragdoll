using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ragdoll
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private int points = 1;

        public void AddPoints()
        {
            GameManager.Points += points;
            Destroy(gameObject);
        }
    }
}