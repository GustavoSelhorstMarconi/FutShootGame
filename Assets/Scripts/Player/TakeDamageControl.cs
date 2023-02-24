using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerControl playerControl;
    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private GameObject explosionEffect;

    [Header("Configurations")]
    [SerializeField]
    private ScriptableInformationsPlayer informationsPlayer;
    [SerializeField]
    private float ReSpawnTime;
    private int life;

    private void Start()
    {
        life = informationsPlayer.maxLife;
    }

    private void ReSpawn()
    {
        gameObject.SetActive(true);
        playerControl.OnGoal();
    }

    public void FullLife()
    {
        life = informationsPlayer.maxLife;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            gameObject.SetActive(false);
            GameObject explosionClone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            explosionClone.GetComponent<ParticleSystemRenderer>().material.color = playerRenderer.color;
            Invoke(nameof(ReSpawn), ReSpawnTime);
        }
    }
}