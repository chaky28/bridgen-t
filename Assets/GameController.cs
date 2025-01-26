using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WindArea windArea;
    public WindAreaParticles windAreaParticles;
    public WindAreaParticles windAreaParticles2;
    public WindAreaParticles windAreaParticles3;
    public RightForce rightForce;
    public float maxWindForce = 2;
    private bool windEnabled;
    public int playerLives = 3;
    public CharacterSpawner characterSpawner;
    public BubbleSpawner bubbleSpawner;
    public Character activeCharacter;
    public string gameState; //Spawing, Ready, Preparing, Flying 
    public DetectSavedCharacter detectSavedCharacters;

    public GameObject Logo;
    public GameObject StartButton;
    public GameObject CreditsButton;
    public GameObject QuitButton;
    public GameObject HelpButton;
    public GameObject DeathScreen;
    public GameObject CreditsScreen;
    public GameObject HelpScreen;

    void Start()
    {
        gameState = "Spawning";
        //SpawnAllPlayers();
        windEnabled = false;
        setWind();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Restart the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (gameState == "Spawning")
        {
            return;

        }
     


        if (Input.GetKeyDown(KeyCode.Space) && gameState == "Ready")
        {
            LaunchPlayer();
        }
    }

    private int getSavedCharacters()
    {
        return detectSavedCharacters.savedCharacters;
    }

    public void LaunchPlayer()
    {
        if (gameState == "Ready")
        {

            FindActiveBubble();
            FindActiveCharacter();
            rightForce.applyForceToBubble();
            gameState = "Flying";
        }
    }
    public void LaunchPlayerDown()
    {
        if (gameState == "Ready")
        {

            FindActiveBubble();
            FindActiveCharacter();
            rightForce.applyForceToBubbleDown();
            gameState = "Flying";
        }
    }

    void setWind()
    {
        float randomWindX = Random.Range(-maxWindForce, maxWindForce);
        float randomWindY = Random.Range(-maxWindForce, maxWindForce);
        windArea.SetWind(randomWindX, randomWindY);
        windAreaParticles.windForce = new Vector2(randomWindX, randomWindY);
        windAreaParticles2.windForce = new Vector2(randomWindX, randomWindY);
        windAreaParticles3.windForce = new Vector2(randomWindX, randomWindY);
    }

    void disableWind()
    {
        windArea.enabled = false;
        windArea.GetComponent<BoxCollider2D>().enabled = false;
        windEnabled = false;
        setWind(); // When disabling the wind, set a new random wind for the next round
    }

    void enableWind()
    {
        windArea.enabled = true;
        windArea.GetComponent<BoxCollider2D>().enabled = true;
        windEnabled = true;
    }

    int GetLives()
    {
        return playerLives;
    }

    void LoseLife()
    {
        playerLives -= 1;
    }

    void FindActiveCharacter()
    {
        var characters = FindObjectsByType<Character>(FindObjectsSortMode.None);
        Character targetCharacter = characters.FirstOrDefault(character => character.isCurrentCharacter);
        activeCharacter = targetCharacter;
    }

    void FindActiveBubble()
    {
        rightForce = FindFirstObjectByType<RightForce>();
    }


    void SpawnNewCharacter()
    {
        activeCharacter.setAsNotCurrentCharacter();
        characterSpawner.SpawnNewCharacter();

    }

    public void SpawnAllPlayers()
    {
        characterSpawner.SpawnAllCharacters();
    }

    public void SetGameReady(bool force_ready = false)
    {
        if (gameState == "Lost" && !force_ready)
        {
            return;
        } 
        HideAllUI();
        bubbleSpawner.SpawnNewBubble();
        FindActiveCharacter();
        activeCharacter.HopOnBubble();
        setWind();
        gameState = "Ready";
    }

    public void SetGamePreparing()
    {
        if (gameState == "Lost"){
            return;
        }
        gameState = "Spawning";

    }

    public void LoseGame()
    {
        gameState = "Lost";
        HideAllUI();
        Invoke("ShowLoseScreen", 1.25f);
    }

    public void HideAllUI()
    {
        Debug.Log("HIDING");
        Logo.SetActive(false);
        StartButton.SetActive(false);
        CreditsButton.SetActive(false);
        QuitButton.SetActive(false);
        HelpButton.SetActive(false);
        DeathScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        HelpScreen.SetActive(false);
    }
    
    public void ShowCredits()
    {
        HideAllUI();
        CreditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        HideAllUI();
        ShowStartMenu();
    }

    public void ShowHelpScreen()
    {
        HideAllUI();
        HelpScreen.SetActive(true);
    }

    public void CloseHelpScreen()
    {
        HideAllUI();
        ShowStartMenu();
    }
    public void ShowStartMenu()
    {
        Logo.SetActive(true);
        StartButton.SetActive(true);
        CreditsButton.SetActive(true);
        HelpButton.SetActive(true);

    }

    void ShowLoseScreen()
    {
        DeathScreen.SetActive(true);
        TextMeshPro textMesh = DeathScreen.GetComponentInChildren<TextMeshPro>();
        int savedChars = detectSavedCharacters.savedCharacters;
        string new_text = "";
        if (savedChars == 0)
        {
            new_text = "You didn't help anyone get to the other side.";
        }
        else if (savedChars == 1)
        {
            new_text = "You helped 1 friend get to the other side!";
        }
        else {
            new_text = "You helped " + savedChars + " friends get to the other side!";
        }
        textMesh.text = new_text;
    }
}

