using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(BoxCollider))]
public class LoopRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("delete last city block and add citybloc on front.");
        }
    }
}
