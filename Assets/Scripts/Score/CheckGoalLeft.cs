using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckGoalLeft : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private UnityEvent OnGoalLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallControl>())
        {
            OnGoalLeft?.Invoke();
        }
    }
}