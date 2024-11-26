using UnityEngine;

public class EnemyDamager : Damager
{
    private void OnEnable()
    {
        AttackTrigger.Triggerd += base.Attack;
    }

    private void OnDisable()
    {
        AttackTrigger.Triggerd -= base.Attack;
    }
}
