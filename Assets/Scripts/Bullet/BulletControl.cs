using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private int damage;
    [SerializeField]
    public float timeToDestroy;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<TakeDamageControl>())
        {
            other.gameObject.GetComponent<TakeDamageControl>().TakeDamage(damage);
        }
    }
}