using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected Enemy enemyPlayer;
    protected Rigidbody playerRb;
    protected bool canMove;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        enemyPlayer = GameObject.Find("Target").GetComponent<Enemy>();
    }


    protected void Move(float speed,Rigidbody playerRb)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(horizontalInput * speed,0, verticalInput * speed);
    }
    

    protected virtual void DealDamage(Enemy target,int damage)
    {
        target.Health -= damage;
        if (target.Health > 0)
        {
            Debug.Log("Enemy Health is now :" + target.Health);
        }
        else
        {
            Debug.Log("Enemy Health is now :0");
        }
    }

    protected abstract void Ability(Enemy target);

    protected void CheckDamageAndAbility(int normalDamage, int abilityDamage)
    {
        if (canMove && Input.GetKeyDown(KeyCode.F))
        {
            Ability(enemyPlayer);
            DealDamage(enemyPlayer, abilityDamage);
        }
        if (canMove && Input.GetKeyDown(KeyCode.R))
        {
            DealDamage(enemyPlayer, normalDamage);
        }
    }

    protected void CanMove(int playerNumber)
    {
        if (playerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                canMove = false;

            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                canMove = true;
                Debug.Log("Thief can now move");
            }
        }
        else if(playerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                canMove = true;
                Debug.Log("Warrior can now move");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                canMove = false;
            }
        }
    }
}
