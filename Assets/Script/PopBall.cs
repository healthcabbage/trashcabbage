using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopBall : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void EscapeGame()
    {
        Application.Quit();
    }
}
