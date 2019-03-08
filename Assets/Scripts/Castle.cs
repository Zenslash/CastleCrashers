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

    [SerializeField]
    private Castle _enemyCastle;


    private int totalUnitsPrefabs;

    #endregion

    #region Public Variables

    public string FactionName;

    #endregion


    #region Callbacks

    private void Start()
    {
        Init();

        //For development purpose
        StartCoroutine(TEST_DeployUnitsWithDelay(2f));
    }

    #endregion


    #region Private Methods

    private void Init()
    {
        totalUnitsPrefabs = _unitsPrefabs.Length;
    }


    private IEnumerator TEST_DeployUnitsWithDelay(float delay)
    {
        spawnUnit(UNIT_TYPE.KNIGHT);
        yield return new WaitForSeconds(delay);
        StartCoroutine(TEST_DeployUnitsWithDelay(delay));
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
                KnightUnit comp = npc.GetComponent<KnightUnit>();
                comp.EnemyCastle = _enemyCastle;
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
