using UnityEngine;

namespace CityRun
{
    public class GroundChecker : MonoBehaviour
    {
        [HideInInspector]public bool isGrounded = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}
