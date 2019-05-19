using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchTutorial()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchOutOfTutorial()
    {
        SceneManager.LoadScene(0);
    }
}
