using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkinPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private ScriptableSkinSelected playerSkinValue;

    [Header("Configurations")]
    [SerializeField]
    private int playerSkin;

    public void SetSkinValue(int playerToSetSkin, int skinSelected)
    {
        if (playerSkin != playerToSetSkin)
        {
            return;
        }
        playerSkinValue.indexSelectedColor = skinSelected;
    }
}