using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] charactersToSpawn;
    public Transform spawnLocation;
    public Transform location1;
    public Transform location2;
    public Transform location3;


    public int numberOfCharacters;
    public Character character_0;
    public Character character_1;
    public Character character_2;
    public Character character_3;

    public GameController gameController;
    public SoundController soundController;

    void Start()
    {
        int numberOfCharacters = 0;
        if (soundController == null)
        {
            soundController = FindFirstObjectByType<SoundController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            soundController.PlaySound("StartUp");
            SpawnAllCharacters();
            //SpawnNewCharacter();
        }
    }

    public void SpawnNewCharacter()
    {

        int index = Random.Range(0, 5);
        Instantiate(charactersToSpawn[index], spawnLocation.transform.position, Quaternion.identity);
    }

    public void SpawnAllCharacters()
    {

        int index = Random.Range(0, 5);
        Invoke("SpawnFirstPlayer", 0.1f);
        Invoke("SpawnSecondPlayer", 1f);
        Invoke("SpawnThirdPlayer", 2f);
        Invoke("SpawnCharacterZero", 2f);
        Invoke("SetGameReady", 4f);
        numberOfCharacters = 4;
    }

    void SpawnFirstPlayer()
    {
        int index = Random.Range(0, 5);

        Character spawned_character_3 = Instantiate(charactersToSpawn[index], spawnLocation.transform.position, Quaternion.identity).GetComponent<Character>();
        spawned_character_3.MoveToPoint(location3);
        spawned_character_3.setAsCurrentCharacter();
        character_3 = spawned_character_3;
        

    }
    
    void SpawnSecondPlayer()
    {
        int index = Random.Range(0, 5);

        Character spawned_character_2 = Instantiate(charactersToSpawn[index], spawnLocation.transform.position, Quaternion.identity).GetComponent<Character>();
        spawned_character_2.MoveToPoint(location2);
        character_2 = spawned_character_2;
    }

    void SpawnThirdPlayer()
    {
        int index = Random.Range(0, 5);

        Character spawned_character_1 = Instantiate(charactersToSpawn[index], spawnLocation.transform.position, Quaternion.identity).GetComponent<Character>();
        spawned_character_1.MoveToPoint(location1);
        character_1 = spawned_character_1;
    }

    void SpawnCharacterZero()
    {
        int index = Random.Range(0, 5);

        Character spawned_character_0 = Instantiate(charactersToSpawn[index], spawnLocation.transform.position, Quaternion.identity).GetComponent<Character>();
        character_0 = spawned_character_0;
    }

    void SetGameReady()
    {
        gameController.SetGameReady(false);
    }

    void SetGamePreparing()
    {
        gameController.SetGamePreparing();
    }
    public void ReplacePlayers()
    {
        character_3.setAsNotCurrentCharacter();
        SetGamePreparing();
        character_3 = character_2;
        character_3.MoveToPoint(location3);
        character_3.setAsCurrentCharacter();
        character_2 = character_1;
        character_2.MoveToPoint(location2);
        character_1 = character_0;
        character_1.MoveToPoint(location1);
        SpawnCharacterZero();
        Invoke("SetGameReady", 1.5f);

    }

}
