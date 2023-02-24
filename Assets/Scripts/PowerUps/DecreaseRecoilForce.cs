using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseRecoilForce : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private float recoilForceDecreased;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Shoot shootPlayer;
        if (other.gameObject.TryGetComponent<Shoot>(out shootPlayer))
        {
            shootPlayer.SetRecoilForcePowerUp(recoilForceDecreased);
            Destroy(gameObject);
        }
    }
}