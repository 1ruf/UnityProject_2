using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public void FlipNpc(Npc npc)
    {
        SpriteRenderer _sprite = npc.GetComponentInChildren<SpriteRenderer>();
        if (npc.RbCompo.velocity.x > 0) _sprite.flipX = false;
        else if (npc.RbCompo.velocity.x < 0) _sprite.flipX = true;
    }
}
