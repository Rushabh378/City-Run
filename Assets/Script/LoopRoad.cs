using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CityRun
{
    [RequireComponent(typeof(BoxCollider))]
    public class LoopRoad : MonoBehaviour
    {
        public static event Action PassedArea;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                PassedArea?.Invoke();
                Debug.Log("delete last city block and add citybloc on front.");
            }
        }
    }
}
