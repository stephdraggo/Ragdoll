using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ragdoll
{
    public class Spin : MonoBehaviour
    {
        [SerializeField] private float speed;


        void Update()
        {
            Vector3 oldRotation = transform.rotation.eulerAngles;
            float newY = oldRotation.y + Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(oldRotation.x, newY, oldRotation.z);
        }
    }
}