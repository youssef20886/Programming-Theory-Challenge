using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Unit
{
    int player = 2;
    int normalDamage = 15;
    int abilityDamage = 40;

    private void FixedUpdate()
    {
        int speed = 10;
        if (canMove)
        {
            Move(speed, playerRb);
        }
    }

    private void Update()
    {
        CanMove(player);
        CheckDamageAndAbility(normalDamage, abilityDamage);
    }

    protected override void Ability(Enemy target)
    {
        Vector3 offset = new Vector3(0, 0, 5);

        if (transform.position != target.gameObject.transform.position + offset)
        {
            transform.position = target.gameObject.transform.position + offset;
        }
        else
        {
            transform.position = target.gameObject.transform.position - offset;
        }
    }
        
}
