using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{
    [SerializeField] Sprite Skin1;
    [SerializeField] Sprite Skin2;
    [SerializeField] Sprite Skin3;

    [SerializeField] public List<SpriteRenderer> spriteRenderers;

    private void Start()
    {
        spriteRenderers[0].sprite = Skin1;
    }

    public void CambiarSprite(int skin)
    {
        if (skin == 1)
        {
            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].sprite = Skin1;
            }
        }
        if (skin == 2)
        {
            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].sprite = Skin2;
            }
        }
        if (skin == 3)
        {
            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                spriteRenderers[i].sprite = Skin3;
            }
        }
    }
}
