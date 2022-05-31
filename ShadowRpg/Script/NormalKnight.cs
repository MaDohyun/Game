using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalKnight : Shadow
{
    public override void TakeDamege(float damage)
    {
        if(actionState == ActionState.Skill)
        {
            if (HP > 0)
            {
                this.GetComponent<Animator>().SetBool("Skill", false);
                CreateStateText("Block");
            }
        }
        else
        {
            base.TakeDamege(damage);
        }
    }
  
        public override void Attack()
    {
        if (actionState != ActionState.Skill)
        {
            targetEnemy.TakeDamege(DAMAGE);
        }
        else
        {

            animator.SetBool("Skill", false);
            CreateStateText("Counter");
            targetEnemy.TakeDamege(DAMAGE*2);
        }

    }


}
