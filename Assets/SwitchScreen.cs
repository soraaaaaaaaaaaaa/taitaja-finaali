using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
