using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D ballRigidBody;

    [Header("Configurations")]
    [SerializeField]
    private float scaleIncreased;
    [SerializeField]
    private float scaleDecreased;
    [SerializeField]
    private float timeToRestartScale;

    private Vector2 startPosition;
    private Vector3 startScale;

    private void Start()
    {
        startPosition = transform.position;
        startScale = transform.localScale;
    }

    public void OnGoal()
    {
        transform.position = startPosition;
        ballRigidBody.velocity = Vector2.zero;
    }

    public void IncreaseBallSizePowerUp()
    {
        transform.localScale = new Vector3(scaleIncreased, scaleIncreased, scaleIncreased);
        Invoke(nameof(RestartScale), timeToRestartScale);
    }

    public void DecreaseBallSizePowerUp()
    {
        transform.localScale = new Vector3(scaleDecreased, scaleDecreased, scaleDecreased);
        Invoke(nameof(RestartScale), timeToRestartScale);
    }

    private void RestartScale()
    {
        transform.localScale = startScale;
    }
}