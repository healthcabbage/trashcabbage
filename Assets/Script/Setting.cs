using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject Finalpanel;

    public void OnPanel()
    {

        Time.timeScale = 0;
        Debug.Log("세팅 클릭됨");
        Finalpanel.SetActive(true);
    }
    public void OffPanel()
    {
        Time.timeScale = 1;
        Debug.Log("재시작 클릭됨");
        Finalpanel.SetActive(false);
    }
    public void Nagagi()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

       public void reTry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
