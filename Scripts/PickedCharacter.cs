using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject knight, peasant, soldier, merchant, priest, thief;

    void Start()
    {
        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.SpawnCharacter(knight, "BlueTeam");
        spawner.SpawnCharacter(merchant, "RedTeam");
        spawner.SpawnCharacter(soldier, "RedTeam");
        spawner.SpawnCharacter(peasant, "BlueTeam");
        spawner.SpawnCharacter(priest, "RedTeam");
        spawner.SpawnCharacter(thief, "BlueTeam");
    }
}
