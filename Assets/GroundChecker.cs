using UnityEngine;

namespace CityRun
{
    public class GroundChecker : MonoBehaviour
    {
        [HideInInspector]public static bool isGrounded = true;

        private void OnTriggerEnter(Collider other)
        {
            isGrounded = true;
        }
        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
        }
    }
}
