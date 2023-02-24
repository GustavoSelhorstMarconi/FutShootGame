using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        ResizeSprite();
    }

    private void ResizeSprite()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        transform.localScale = new Vector3(1, 1, 1);

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;
    }
}