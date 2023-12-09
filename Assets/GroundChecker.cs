using UnityEngine;

namespace CityRun
{
    public class GroundChecker : MonoBehaviour
    {
        [HideInInspector]public bool isGrounded = true;

        private void OnTriggerEnter(Collider other)
        {
            isGrounded = true;
            Debug.Log("on ground");
        }
        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
            Debug.Log("on air");
        }
    }
}
