using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickedCharacters : MonoBehaviour
{
    [SerializeField]
    private static PickedCharacters Instance;
    [SerializeField]
    private List<GameObject> _pickedCharacters;
    private int pickNumber = 1;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_pickedCharacters.Count != 0)
        {
            Spawner spawner = FindObjectOfType<Spawner>();

            for (int i = 0; i < pickNumber - 1; i++)
            {
                spawner.SpawnCharacter(_pickedCharacters[i]);
            }

            Destroy(gameObject);
        }
    }

    public void AddPickerCharacter(GameObject character)
    {
        if (pickNumber % 2 == 0)
        {
            character.tag = "RedTeam";
        }
        else
        {
            character.tag = "BlueTeam";
        }

        pickNumber++;
        _pickedCharacters.Add(character);

        if (pickNumber > 6)
        {
            SceneManager.LoadScene("Arena");
        }
    }
}