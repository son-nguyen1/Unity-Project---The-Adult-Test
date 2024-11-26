using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Instructions and Positions
    [SerializeField] private GameObject instructionMouse;
    private Vector3 positionMouse = new Vector3(0f, 4.75f, 0f);

    [SerializeField] private GameObject instructionQ;
    private Vector3 positionQ = new Vector3(-10.5f, 3f, 0f);

    [SerializeField] private GameObject instructionR;
    private Vector3 positionR = new Vector3(10.5f, 3f, 0f);

    [SerializeField] private GameObject instructionS;
    private Vector3 positionS = new Vector3(-10.5f, 1f, 0f);

    [SerializeField] private GameObject instructionD;
    private Vector3 positionD = new Vector3(10.5f, 1f, 0f);

    [SerializeField] private GameObject instructionX;
    private Vector3 positionX = new Vector3(-10.5f, -3f, 0f);

    [SerializeField] private GameObject instructionSpace;
    private Vector3 positionSpace = new Vector3(10.5f, -3f, 0f);

    // Scripts
    private TextManager textManager;
    private InputManager inputManager;
    private AudioManager audioManager;
    private GameManager gameManager;

    private CameraShake cameraShake;

    private float instructionTime = 2f;
    private float[] waitTime = { 3f, 4f, 5f };

    private void Start()
    {
        textManager = FindObjectOfType<TextManager>();
        inputManager = FindObjectOfType<InputManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = GetComponent<GameManager>();

        cameraShake = FindObjectOfType<CameraShake>();

        // Disable the gameplay input
        inputManager.DisableDragObject();
        inputManager.DisableSwingObject();
        inputManager.DisableResizeObject();
        inputManager.DisableRecolorObject();
    }    

    public IEnumerator StartMouseDrag()
    {
        // Play the sarcastic commentary
        audioManager.PlaySound(0);
        yield return StartCoroutine(textManager.StartType(0));
        yield return StartCoroutine(textManager.StartType(1));
        yield return StartCoroutine(textManager.StartType(2));
        yield return StartCoroutine(textManager.StartType(3));
        yield return StartCoroutine(textManager.StartType(4));

        // Enable the gameplay input
        inputManager.EnableDragObject();

        // Enable the instruction, with a pause for fade in effect
        Instantiate(instructionMouse, positionMouse, Quaternion.identity);
        yield return new WaitForSeconds(instructionTime);

        // Initiate the challenge, with sounds and pause in between
        audioManager.PlaySound(1);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[0]);

        audioManager.PlaySound(2);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[0]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[0]);

        // Start the next sequence
        StartCoroutine(StartBrowSwing());
    }

    private IEnumerator StartBrowSwing()
    {
        // Play the sarcastic commentary
        yield return StartCoroutine(textManager.StartType(5));
        yield return StartCoroutine(textManager.StartType(6));

        // Enable the gameplay input
        inputManager.EnableSwingBrow();

        // Enable the instruction, with a pause for fade in effect
        Instantiate(instructionQ, positionQ, Quaternion.identity);
        Instantiate(instructionR, positionR, Quaternion.identity);
        yield return new WaitForSeconds(instructionTime);

        // Initiate the challenge, with sounds and pause in between
        audioManager.PlaySound(3);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[1]);

        audioManager.PlaySound(4);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[1]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[1]);

        // Start the next sequence
        StartCoroutine(StartEyeResize());
    }

    private IEnumerator StartEyeResize()
    {
        // Play the sarcastic commentary
        yield return StartCoroutine(textManager.StartType(7));
        yield return StartCoroutine(textManager.StartType(8));

        // Enable the gameplay input
        inputManager.EnableResizeObject();

        // Enable the instruction, with a pause for fade in effect
        Instantiate(instructionS, positionS, Quaternion.identity);
        Instantiate(instructionD, positionD, Quaternion.identity);
        yield return new WaitForSeconds(instructionTime);

        // Initiate the challenge, with sounds and pause in between
        audioManager.PlaySound(5);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        audioManager.PlaySound(6);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        // Start the next sequence
        StartCoroutine(StartMouthSwing());
    }

    private IEnumerator StartMouthSwing()
    {
        // Play the sarcastic commentary
        yield return StartCoroutine(textManager.StartType(9));
        yield return StartCoroutine(textManager.StartType(10));

        // Enable the gameplay input
        inputManager.EnableSwingMouth();

        // Enable the instruction, with a pause for fade in effect
        Instantiate(instructionX, positionX, Quaternion.identity);
        yield return new WaitForSeconds(instructionTime);

        // Initiate the challenge, with sounds and pause in between
        audioManager.PlaySound(7);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        audioManager.PlaySound(8);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        // Start the next sequence
        StartCoroutine(StartBackgroundRecolor());
    }

    private IEnumerator StartBackgroundRecolor()
    {
        // Play the sarcastic commentary
        yield return StartCoroutine(textManager.StartType(11));
        yield return StartCoroutine(textManager.StartType(12));

        // Enable the gameplay input
        inputManager.EnableRecolorObject();

        // Enable the instruction, with a pause for fade in effect
        Instantiate(instructionSpace, positionSpace, Quaternion.identity);
        yield return new WaitForSeconds(instructionTime);

        // Initiate the challenge, with sounds and pause in between
        audioManager.PlaySound(9);
        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        ShakeCameraAndFace();
        yield return new WaitForSeconds(waitTime[2]);

        // Start the next sequence
        StartCoroutine(StartCongratulation());
    }

    private IEnumerator StartCongratulation()
    {
        // Disable the gameplay input
        inputManager.DisableDragObject();
        inputManager.DisableSwingObject();
        inputManager.DisableResizeObject();
        inputManager.DisableRecolorObject();

        // Disable all sounds
        audioManager.StopAllSounds();

        // Play the robotic and clapping sound
        audioManager.PlaySound(0);
        audioManager.PlaySound(10);

        // Play the sarcastic commentary
        yield return StartCoroutine(textManager.StartType(13));
        yield return StartCoroutine(textManager.StartType(14));
        yield return StartCoroutine(textManager.StartType(15));

        // Disable all sounds
        audioManager.StopAllSounds();
        gameManager.EnableRestartButton();
    }

    private void ShakeCameraAndFace()
    {
        cameraShake.ShakeCamera();
        inputManager.ShakeObject();
    }    
}