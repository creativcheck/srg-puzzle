using Services;
using System.Collections.Generic;
using UnityEngine;

namespace InteractiveObjects
{
    public class InteractiveButton : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objectsToInteract;
        [SerializeField] private bool _turnOnOrOff;
        [SerializeField] private LayerMask _launchLayer;

        private void Start()
        {
            for (int i = 0; i < _objectsToInteract.Count; i++)
            {
                _objectsToInteract[i].SetActive(!_turnOnOrOff);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(LayerService.CheckLayersEquality(collision.gameObject.layer, _launchLayer))
            {
                for (int i = 0; i < _objectsToInteract.Count; i++)
                {
                    _objectsToInteract[i].SetActive(_turnOnOrOff);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

    }

}
