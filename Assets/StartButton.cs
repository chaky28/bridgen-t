using System;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameController gameController;
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameController.ShowGame();
        gameController.HideAllUI();
        gameController.SpawnAllPlayers();
    }
}
