using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    public float distToPlayer2 = 0;

    public override void Move()
    {
        // Transform player_loc = base.Player.transform;
        
        // if(Vector2.Distance(player_loc.position, transform.position) > distToPlayer2)
        // {
        //     transform.position = Vector3.MoveTowards (transform.position, player_loc.position, Time.deltaTime * base.moveSpeed);
        // }
    }
}
