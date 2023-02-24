using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerInformations")]
public class ScriptableInformationsPlayer : ScriptableObject
{
    public float recoilForce;
    public float shootForce;
    public int maxLife;
}