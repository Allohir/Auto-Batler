using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject knight;
    [SerializeField]
    GameObject peasant;
    [SerializeField]
    GameObject soldier;

    void Start()
    {
        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.SpawnCharacter(knight, "BlueTeam");
        spawner.SpawnCharacter(peasant, "RedTeam");
        spawner.SpawnCharacter(soldier, "RedTeam");
        spawner.SpawnCharacter(peasant, "BlueTeam");
    }
}
