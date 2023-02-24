using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D playerRigidBody;
    [SerializeField]
    private TakeDamageControl playerDamageControl;
    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private ScriptableSkinSelected skinSelected;
    [SerializeField]
    private ScriptableColors colorsSkin;
    [SerializeField]
    private GameObject barrer;

    [Header("Configurations")]
    [SerializeField]
    private float timeToDesactivateBarrer;

    private Vector2 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        playerRenderer.color = colorsSkin.skinColors[skinSelected.indexSelectedColor];
    }

    public void OnGoal()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        playerRigidBody.velocity = Vector2.zero;
        playerDamageControl.FullLife();
    }

    public void ActivateBarrer()
    {
        barrer.SetActive(true);
        Invoke(nameof(DesactivateBarrer), timeToDesactivateBarrer);
    }

    private void DesactivateBarrer()
    {
        barrer.SetActive(false);
    }
}