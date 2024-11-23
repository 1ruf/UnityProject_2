using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorManager : MonoBehaviour
{
    private bool _powered;


    public void ElevatorPowerOn()
    {
        _powered = true;
    }
    public void PowerElevatorConnect()
    {
        if (_powered == true)
        {
            nextStage();
        }
    }
    public void ElevatorConnect()
    {
        nextStage();
    }
    private void nextStage()
    {
        SaveManager.Instance.SetData((int)Datas.Stage2, true);
        SceneManager.LoadScene("Stage2");
    }
}
