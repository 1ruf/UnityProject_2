using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc
{
    [field : SerializeField] public override InputReader InputCompo { get; protected set; }




    

    

    public void CharacterChangeed(/*enemySO enemyData*/) 
    {
        CreateDummy(_spriteRenderer.sprite, transform);


        /*AnimCompo = enemyData.Anim;
        _spriteRenderer.sprite = enemyData.sprite;
        _playerData.maxHealth = enemyData.maxHealth;
        _playerData.moveSpeed = enemyData.moveSpped;
        transform.position = enemyData.transform.position;
        transform.localScale = enemyData.transform.localScale;*/
        
    }

    private void CreateDummy(Sprite sprite, Transform trans)
    {
        
    }
}
