using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Load a scene by its name
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
