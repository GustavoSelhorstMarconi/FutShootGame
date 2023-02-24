using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckGoalRight : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private UnityEvent OnGoalRight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallControl>())
        {
            OnGoalRight?.Invoke();
        }
    }
}