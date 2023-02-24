using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRecoilForce : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private float recoilForceIncreased;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Shoot shootPlayer;
        if (other.gameObject.TryGetComponent<Shoot>(out shootPlayer))
        {
            shootPlayer.SetRecoilForcePowerUp(recoilForceIncreased);
            Destroy(gameObject);
        }
    }
}