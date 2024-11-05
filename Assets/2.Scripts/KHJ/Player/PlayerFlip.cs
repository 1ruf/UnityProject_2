using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public void Flip(Player agent)
    {
        SpriteRenderer _sprite = agent.GetComponent<SpriteRenderer>();
        if (agent.RbCompo.velocity.x > 0) _sprite.flipX = false;
        else if (agent.RbCompo.velocity.x < 0) _sprite.flipX = true;
    }
}
