using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSlimeSkillState : StateMachineBehaviour
{
    Transform enemyTransForm;
    Enemy enemy;
    int target;
    int random;
    Vector3 vector3;

    //ブラックスライムはスキルアニメになると攻撃範囲にあるランダムなキャラクターをターゲットにする。あるいは一番前のキャラクターをターゲットにする。
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransForm = animator.GetComponent<Transform>();
        if (enemy.battlePositionNumber - enemy.RANGE > 0)
        {
            target = 0;
            vector3 = new Vector3(Player.instance.battleShadowList[target].transform.position.x + 1.5f, enemyTransForm.position.y, enemyTransForm.position.z);
            //ターゲットの前に移動する。
            enemyTransForm.position = vector3;

        }
        else if (enemy.battlePositionNumber - enemy.RANGE <= 0)
        {
            if (Player.instance.battleShadowList.Count >= enemy.RANGE - enemy.battlePositionNumber + 1)
            {
                random = Random.Range(0, enemy.RANGE - enemy.battlePositionNumber + 1);
                target = random;

                vector3 = new Vector3(Player.instance.battleShadowList[target].transform.position.x + 1.5f, enemyTransForm.position.y, enemyTransForm.position.z);
                //ターゲットの前に移動する。
                enemyTransForm.position = vector3;

            }
            else if (Player.instance.battleShadowList.Count < enemy.RANGE - enemy.battlePositionNumber + 1)
            {
                random = Random.Range(0, Player.instance.battleShadowList.Count - 1);
                target = random;

                vector3 = new Vector3(Player.instance.battleShadowList[target].transform.position.x + 1.5f, enemyTransForm.position.y, enemyTransForm.position.z);
                //ターゲットの前に移動する。
                enemyTransForm.position = vector3;

            }
        }
        enemy.targetShadow = Player.instance.battleShadowList[target].GetComponent<Shadow>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        vector3 = new Vector3(enemy.battlePosition.position.x, enemyTransForm.position.y, enemyTransForm.position.z);
        //元の位置に戻る。
        enemyTransForm.position = vector3;

    }
}
