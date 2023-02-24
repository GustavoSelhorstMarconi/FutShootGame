using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private float rotateSpeed;

    void Update()
    {
        // transform.position = player.position;
        transform.Rotate(new Vector3(0f, 0f, rotateSpeed) * Time.deltaTime);
    }
}