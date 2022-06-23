using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionWalk : StateMachineBehaviour
{
    private bool movingRight = false;
    private float speed = 3.5f;
    private float impactAtkRange = 7f;
    Transform player;
    Rigidbody2D rb;
    ScorpionBoss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<ScorpionBoss>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        boss.FlipX();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
        */

        /*
        if (Vector2.Distance(player.position, rb.position) >= 5 && Vector2.Distance(player.position, rb.position) < 10)
        {
            Vector2 target = new(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            float distPlayerBoss = (rb.position.x - player.position.x) + rb.position.x;
            Vector2 target = new(distPlayerBoss, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
        */

        
        //boss.FlipX();
        if (rb.transform.position.x < boss.forRight.transform.position.x)
        {
            movingRight = true;
        }
        if (rb.transform.position.x > boss.forLeft.transform.position.x)
        {
            movingRight = false;
        }

        if (movingRight)
        {
            rb.transform.position = new Vector2(rb.transform.position.x + speed * Time.deltaTime, rb.transform.position.y);
        }
        else
        {
            rb.transform.position = new Vector2(rb.transform.position.x - speed * Time.deltaTime, rb.transform.position.y);
        }
        
        

        if (Vector2.Distance(player.position, rb.position) <= impactAtkRange)
        {
            animator.SetTrigger("ImpactAtk");
        }

        if (
            (Vector2.Distance(player.position, rb.position) >= 10 && Vector2.Distance(player.position, rb.position) < 14)
            ||
            (Vector2.Distance(player.position, rb.position) >= 18 && Vector2.Distance(player.position, rb.position) < 22)
           )
        {
            animator.SetTrigger("RangeAtk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ImpactAtk");
        animator.ResetTrigger("RangeAtk");
    }
}
