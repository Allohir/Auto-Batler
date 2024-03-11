using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject knight, peasant, soldier, merchant, priest, thief;

    public void SpawnCharacter(GameObject character, string tag)
    {
        GameObject spawnedCharacter = (GameObject)Instantiate(character);
        spawnedCharacter.tag = tag;
        spawnedCharacter.transform.SetParent(this.transform);

        switch(tag)
        {
            case "BlueTeam":
                spawnedCharacter.transform.localPosition = new Vector2(-500 + Random.Range(-50, 50), 0 + Random.Range(-50, 50));
                Quaternion rot = transform.rotation;
                rot.y = 180;
                spawnedCharacter.transform.localRotation = rot;
                break;
            case "RedTeam":
                spawnedCharacter.transform.localPosition = new Vector2(500 + Random.Range(-50, 50), 0 + Random.Range(-50, 50));
                break;
        }

        spawnedCharacter.transform.localScale = new Vector2(50, 50);
    }

    public void RespawnCharacter(Character character)
    {
        StartCoroutine(Timer(3, character, character.tag));
    }

    IEnumerator Timer(int seconds, Character character, string tag)
    {
        yield return new WaitForSeconds(seconds);
        SpawnCharacter(IdentifyCharacterToSpawn(character), tag);
    }

    private GameObject IdentifyCharacterToSpawn(Character character)
    {  
        switch (character)
        {
            case Knight:
                return knight;
            case Peasant:
                return peasant;
            case Soldier:
                return soldier;
            case Merchant:
                return merchant;
            case Priest:
                return priest;
            case Thief: 
                return thief;
        }

        return null;
    }
}