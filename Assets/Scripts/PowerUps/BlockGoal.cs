using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerControl playerControl;
        if (other.gameObject.TryGetComponent<PlayerControl>(out playerControl))
        {
            playerControl.ActivateBarrer();
            Destroy(gameObject);
        }
    }
}