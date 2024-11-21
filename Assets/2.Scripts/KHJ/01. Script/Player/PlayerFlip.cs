using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public void Flip(Npc npc)
    {
        SpriteRenderer _sprite = npc.GetComponent<SpriteRenderer>();
        if (npc.RbCompo.velocity.x > 0) _sprite.flipX = false;
        else if (npc.RbCompo.velocity.x < 0) _sprite.flipX = true;
    }
}
