using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    
    public void LoadScene()
    {
        if (sceneToLoad != null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        else
            Debug.LogError("Scene name is not set in the inspector.");
    }
}
