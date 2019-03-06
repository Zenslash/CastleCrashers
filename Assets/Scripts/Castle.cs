using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UNIT_TYPE { KNIGHT, ARCHER};

public class Castle : MonoBehaviour
{

    #region Private Variables

    [SerializeField]
    private Transform _unitSpawnPoint;

    [SerializeField]
    private GameObject[] _unitsPrefabs;


    private int totalUnitsPrefabs;

    #endregion

    #region Public Variables


    #endregion


    #region Callbacks

    private void Start()
    {
        Init();

        //For development purpose
        spawnUnit(UNIT_TYPE.KNIGHT);
    }

    #endregion


    #region Private Methods

    private void Init()
    {
        totalUnitsPrefabs = _unitsPrefabs.Length;
    }

    #endregion

    #region Public Methods

    private void spawnUnit(UNIT_TYPE unit_type)
    {

        GameObject npc;
        switch(unit_type)
        {
            case UNIT_TYPE.KNIGHT:

                npc = Instantiate(_unitsPrefabs[0], _unitSpawnPoint);
                //Init stuff

                break;
            case UNIT_TYPE.ARCHER:

                npc = Instantiate(_unitsPrefabs[1], _unitSpawnPoint);
                //Init stuff

                break;
        }

    }

    #endregion

}
