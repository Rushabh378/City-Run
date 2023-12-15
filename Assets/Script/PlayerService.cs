using UnityEngine;

namespace CityRun
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerController player;

        private void Start()
        {
            Instantiate<PlayerController>(player, transform.position, Quaternion.identity);
        }
    }
}
