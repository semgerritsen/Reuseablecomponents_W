using System;
using Movement;
using Movement.inputs;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Timeline;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inputPanel;

    public void LoadScene()
    {
        if (sceneToLoad != null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        else
            Debug.LogError("Scene name is not set in the inspector.");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Application is quitting");
    }

    public void ControllerInputChosen()
    {
        player.AddComponent<SwiftMovement>();
        player.AddComponent<ControllerInput>();
        player.AddComponent<PlayerMove>();
        Cursor.lockState = CursorLockMode.Locked;
        inputPanel.SetActive(false);
    }

    public void KeyboardInputChosen()
    {
        player.AddComponent<SwiftMovement>();
        player.AddComponent<KeyboardInput>();
        player.AddComponent<PlayerMove>();
        Cursor.lockState = CursorLockMode.Locked;
        inputPanel.SetActive(false);
    }
}
