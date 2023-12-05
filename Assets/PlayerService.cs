using UnityEngine;

namespace CityRun
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private GameObject startArea;

        private void Start()
        {
            Instantiate<PlayerController>(player, transform.position, Quaternion.identity);
        }
    }
}
