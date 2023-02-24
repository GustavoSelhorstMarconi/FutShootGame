using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseBallSize : MonoBehaviour
{
    private PowerUpControl powerUpControl;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerControl>())
        {
            powerUpControl.CallPowerUp(gameObject);
            Destroy(gameObject);
        }
    }

    public void SetPowerUpControl(PowerUpControl powerUpControlToSet)
    {
        powerUpControl = powerUpControlToSet;
    }
}