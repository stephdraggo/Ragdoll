using UnityEngine;

namespace Ragdoll
{
    public class CamMovement : MonoBehaviour
    {
        public static CamMovement Instance;

        public bool hasSelected;
        
        [SerializeField] private float speed = 1;

        [SerializeField] private Transform crosshair;
        public Transform Crosshair => crosshair;

        void Awake()
        {
            Instance = this;
            hasSelected = false;
        }

        void FixedUpdate()
        {
            transform.position += GetInput();
        }

        private Vector3 GetInput()
        {
            float x = 0;
            float z = 0;
            if (Input.GetKey(KeyCode.A)) x--;
            if (Input.GetKey(KeyCode.D)) x++;
            if (Input.GetKey(KeyCode.W)) z++;
            if (Input.GetKey(KeyCode.S)) z--;
            float y = -Input.mouseScrollDelta.y;
            return new Vector3(x, y, z) * (speed * Time.deltaTime);
        }
    }
}