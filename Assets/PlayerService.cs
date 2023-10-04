using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private GameObject startArea;

        private void Start()
        {
            Instantiate<PlayerController>(player, startArea.transform.position, Quaternion.identity);
        }
    }
}
