using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Unit
{
    int player = 1;
    int normalDamage = 30;
    int abilityDamage = 50;

    private void FixedUpdate()
    {
        int speed = 5;
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
        StartCoroutine(DashAbility(enemyPlayer));
    }

    IEnumerator DashAbility(Enemy enemy)
    {
        
        int abiltySpeed = 20;
        Vector3 startingPos = transform.position;
        Vector3 endPos = enemy.gameObject.transform.position;
        float journeyLength = Vector3.Distance(startingPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * abiltySpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * abiltySpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startingPos, endPos, fractionOfJourney);
            yield return null;
        }

    }


}
