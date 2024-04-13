using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [SerializeField] private GameObject[] turrets;
    private int selectedTurret = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject GetTurretToBuild()
    {
        return turrets[selectedTurret];;
    }
    public void SelectTurret(int index)
    {
        selectedTurret = index;
   }
}
