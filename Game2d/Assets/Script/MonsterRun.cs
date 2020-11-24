using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRun : StateMachineBehaviour
{
    public float speed = 0.5f;
    public float attackRange = 2f;


    public Transform player;

    Rigidbody2D r2d;
    Monster monster;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        r2d = animator.GetComponent<Rigidbody2D>();
        monster = animator.GetComponent<Monster>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, r2d.position.y);
        Vector2 newPos = Vector2.MoveTowards(r2d.position, target, speed * Time.deltaTime);
        r2d.MovePosition(newPos);

        if (Vector2.Distance(player.position, r2d.position) < attackRange)
        {
            animator.SetTrigger("attack");
            
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

            animator.ResetTrigger("attack");
    }



}
