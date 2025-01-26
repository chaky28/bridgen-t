using System;
using UnityEngine;

public class HelpButton : MonoBehaviour
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
        gameController.HideAllUI();
        gameController.ShowHelpScreen();
    }
}
