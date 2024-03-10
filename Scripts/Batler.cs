using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batler : MonoBehaviour
{
    public static void CalculateAttackResult(Character attacker, Character defender)
    {
        if(attacker == null || defender == null) return;
        float damage = attacker.GetAttackDamage() - defender.GetDefence();

        if(damage < 1)
        {
            damage = 1;
        }

        float defenderHealth = defender.GetHealth();

        if (defenderHealth - damage <= 0)
        {
            defender.Die();
            Spawner spawner = FindAnyObjectByType<Spawner>();
            spawner.RespawnCharacter(defender);
            Statistic.Kill(attacker);
            Statistic.IncreaseDamageDealed(attacker, defenderHealth);
            Statistic.IncreaseDamageTaken(defender, defenderHealth);
        }
        else
        {
            defender.TakeDamage(damage);
            Statistic.IncreaseDamageDealed(attacker, damage);
            Statistic.IncreaseDamageTaken(defender, damage);
        }
    }
}
