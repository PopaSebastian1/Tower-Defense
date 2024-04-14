using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameType : MonoBehaviour
{
    public static GameType instance;
    public bool isHardMode = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public void SetHardMode(bool _isHardMode)
    {
        isHardMode = _isHardMode;
    }
    public bool GetHardMode()
    {
        return isHardMode;
    }

}
