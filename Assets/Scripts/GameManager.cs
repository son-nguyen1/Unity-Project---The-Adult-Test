using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI Elements
    [SerializeField] private GameObject gameTitle;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;

    // Script
    private GameInput gameInput;

    private void Start()
    {
        gameInput = GetComponent<GameInput>();

        // Click the button to initiate the challenge
        startButton.onClick.AddListener(StartTheTest);
        restartButton.onClick.AddListener(RestartTheTest);
    }

    private void StartTheTest()
    {
        // Disable the button to prevent spam clicks
        startButton.interactable = false;

        gameTitle.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        // Start the challenge
        StartCoroutine(gameInput.StartMouseDrag());
    }

    public void EnableRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    private void RestartTheTest()
    {
        SceneManager.LoadScene(0);
    }
}