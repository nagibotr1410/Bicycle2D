using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenController : MonoBehaviour
{
    public static int CurrentSceneID()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public static void Restart()
    {
        SceneManager.LoadScene(CurrentSceneID());
    }
    public static void NextLevel()
    {
        SceneManager.LoadScene(CurrentSceneID() + 1);
    }
    public static void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
