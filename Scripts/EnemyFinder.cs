using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public static Transform FindEnemy(Character character)
    {
        string tag = "";
        switch(character.tag)
        {
            case "BlueTeam":
                tag = "RedTeam";
                break;
            case "RedTeam":
                tag = "BlueTeam";
                break;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

        if (enemies.Length == 0)
        {
            return null;
        }

        float minimalDistance = Vector2.Distance(enemies[0].transform.position, character.transform.position);
        Transform nearestEnemy = enemies[0].transform;

        for (int i = 1; i < enemies.Length; i++)
        {
            float currentDistance = Vector2.Distance(enemies[i].transform.position, character.transform.position);

            if (currentDistance < minimalDistance)
            {
                minimalDistance = currentDistance;
                nearestEnemy = enemies[i].transform;
            }
        }

        return nearestEnemy;
    }
}