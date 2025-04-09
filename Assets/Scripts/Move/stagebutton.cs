using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stagebutton : MonoBehaviour
{

    public void stage()
    {
        SceneManager.LoadScene("StageScene");
    }
}
