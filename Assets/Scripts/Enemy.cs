using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
        }
    }
    private void Update()
    {
        Dead();
    }

    public void Dead()
    {
        float randomPos = Random.Range(0, 50);

        if (health <= 0)
        {
            transform.position = new Vector3(randomPos, 0, randomPos);
            health = 100;
        }
    }




}
