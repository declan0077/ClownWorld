using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HitStun : MonoBehaviour
{
    [Range(0.1f, 2f)]
    [SerializeField] private float stunDuration;
    [SerializeField] private int flashCount;
    [SerializeField] private Color flashColor;

    private SpriteRenderer spriteRenderer;
    private Color defaultColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public IEnumerator HitStun()
    {
        int numberOfFlashes = flashCount;

        while (numberOfFlashes > 0)
        {
            spriteRenderer.color = defaultColor;
            yield return null;
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(stunDuration/flashCount);
            spriteRenderer.color = defaultColor;
            yield return null;
            numberOfFlashes--;
        }
    }
}
