using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Player player;
    private Animator animator;

    void Start() 
    {
        player = GetComponent<Player>();    
        animator = GetComponent<Animator>();    
    }

    void Update() 
    {
        OnMove();
        OnRun();
    }

    # region Moviment 
    void OnMove()
    {
        if(player.Direction.sqrMagnitude > 0) 
        {
            if(player.IsRolling)
            {
                animator.SetTrigger("isRoll");
            }
            
            animator.SetInteger("transition", 1);
        }
        else 
        {
            animator.SetInteger("transition", 0);
        }

        if(player.Direction.x > 0) 
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(player.Direction.x < 0) 
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun() 
    {
        if(player.IsRunning)
        {
            animator.SetInteger("transition", 2);
        }
    }

    # endregion
}