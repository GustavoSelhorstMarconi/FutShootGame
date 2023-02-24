using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorsInformations")]
public class ScriptableColors : ScriptableObject
{
    public List<Color> skinColors;
}