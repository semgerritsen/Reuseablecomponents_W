using System;
using Movement;
using Movement.inputs;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using Weapons;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject player;
    [FormerlySerializedAs("inputPanel")] [SerializeField] private GameObject Panel;

    /// <summary>
    /// Loads the specified scene when the button is clicked.
    /// </summary>
    public void LoadScene()
    {
        // Check if the sceneToLoad is not null or empty
        if (sceneToLoad != null)
            // Load the scene using Unity's SceneManager
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        else 
            // Log an error if the scene name is not set
            Debug.LogError("Scene name is not set in the inspector.");
    }

    public void Start()
    {
        // set time scale to 0 to pause the game
        Time.timeScale = 0f;
    }

    
    /// <summary>
    /// this method is called when the player chooses controller input.
    /// in the method, we add the necessary components to the player GameObject based on the input method chosen.
    /// </summary>
    public void ControllerInputChosen()
    {
        player.AddComponent<BaseMovement>();
        player.AddComponent<ControllerInput>();
        player.AddComponent<PlayerMove>();
        player.GetComponentInChildren<Camera>()?.transform.GetChild(0)?.gameObject.AddComponent<ControllerAimInput>();
        player.GetComponentInChildren<Camera>()?.transform.GetChild(0)?.gameObject.AddComponent<ControllerWeaponInput>();
        player.GetComponentInChildren<Camera>()?.gameObject.AddComponent<ControllerLook>();
        Cursor.lockState = CursorLockMode.Locked;
        ClosePanel();
        Time.timeScale = 1f;
    }

    public void KeyboardInputChosen()
    {
        player.AddComponent<BaseMovement>();
        player.AddComponent<KeyboardInput>();
        player.AddComponent<PlayerMove>();
        player.GetComponentInChildren<Camera>()?.transform.GetChild(0)?.gameObject.AddComponent<MouseAimInput>();
        player.GetComponentInChildren<Camera>()?.transform.GetChild(0)?.gameObject.AddComponent<MouseWeaponInput>();
        player.GetComponentInChildren<Camera>()?.gameObject.AddComponent<MouseLook>();
        Cursor.lockState = CursorLockMode.Locked;
        ClosePanel();
        Time.timeScale = 1f;
    }

    /// <summary>
    /// method to close the input panel when the player chooses an input method.
    /// This method is called when the player selects either controller or keyboard input.
    /// It sets the Panel GameObject to inactive, effectively closing it.
    /// </summary>
    public void ClosePanel()
    {
        Panel.SetActive(false);
    }

    /// <summary>
    ///  This method is called when the user clicks the quit button.
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Application is quitting");
    }
    
    
}
