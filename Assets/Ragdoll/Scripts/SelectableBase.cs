using System;
using UnityEngine;

namespace Ragdoll
{
    public class SelectableBase : MonoBehaviour
    {
        private bool selected;
        private Transform parent;
        private new Rigidbody rigidbody;

        [SerializeField] private SkinnedMeshRenderer mesh;

        [SerializeField] private Material baseMat, highlighted;

        void OnValidate()
        {
            mesh.material = baseMat;
            parent = transform.parent;
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            mesh.material = baseMat;
            parent = transform.parent;
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (selected)
            {
                transform.position = transform.parent.position;

                if (Input.GetMouseButtonUp(0)) Drop();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            //TryGetComponent(out Collectible collectible
            if (!selected && other.gameObject.layer == LayerMask.NameToLayer("Collectible"))
            {
                GameManager.Instance.points += (int)rigidbody.velocity.magnitude;
                Collectible collectible = other.gameObject.GetComponent<Collectible>();
                collectible.AddPoints();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //TryGetComponent(out Collectible collectible
            if (!selected && other.gameObject.layer == LayerMask.NameToLayer("Collectible"))
            {
                GameManager.Instance.points += (int)rigidbody.velocity.magnitude;
                Collectible collectible = other.gameObject.GetComponent<Collectible>();
                collectible.AddPoints();
            }
        }
        

        private void OnMouseEnter()
        {
            if (!selected && !CamMovement.Instance.hasSelected)
            {
                mesh.material = highlighted;
            }
        }

        private void OnMouseExit()
        {
            mesh.material = baseMat;
        }

        private void OnMouseOver()
        {
            if (!selected && !CamMovement.Instance.hasSelected)
            {
                if (Input.GetMouseButton(0)) Select();
            }
        }

        private void Select()
        {
            selected = true;
            transform.SetParent(CamMovement.Instance.Crosshair);
            CamMovement.Instance.hasSelected = true;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        private void Drop()
        {
            selected = false;
            transform.SetParent(parent);
            CamMovement.Instance.hasSelected = false;
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}