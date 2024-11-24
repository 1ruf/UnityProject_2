using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
    static public FlipManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(this);
        else
            Instance = this;
    }


    public void FlipNpc(Entity entity)
    {
        SpriteRenderer _sprite = entity.GetComponentInChildren<SpriteRenderer>();
        if (entity.RbCompo.velocity.x > 0) _sprite.flipX = false;
        else if (entity.RbCompo.velocity.x < 0) _sprite.flipX = true;
    }
}
