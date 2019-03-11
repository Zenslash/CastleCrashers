using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    [Header("Texture properties")]
    [SerializeField]
    private Sprite _damagedCastle;

    [SerializeField]
    private Sprite _destroyedCastle;

    [Header("Gameplay properties")]
    [SerializeField]
    private int _startCoinsPerTurnValue = 10;
    [SerializeField]
    private float _coinReceiveDelay = 5f;
    [SerializeField]
    private int _castleUpgradeCost = 50;


    private int totalUnitsPrefabs;
    private HealthComponent _castleHealth;
    private bool _isSwitchedToDamageSprite;
    private bool _isCastleDestroyed;

    private int _currentCastleLevel = 1;
    private int _coinsPerTurn;

    #endregion

    #region Public Variables

    public string FactionName;
    public bool IsSpawnUnits;

    #endregion


    #region Callbacks

    private void Start()
    {
        Init();

    }

    private void Update()
    {
        if(!_isSwitchedToDamageSprite && _castleHealth.CurrentHPAsPercent <= 50)
        {
            GetComponent<SpriteRenderer>().sprite = _damagedCastle;
            _isSwitchedToDamageSprite = true;
        }
        else if(!_isCastleDestroyed && _castleHealth.CurrentHP == 0)
        {
            _isCastleDestroyed = true;
            GetComponent<SpriteRenderer>().sprite = _destroyedCastle;
            //Loose game
        }
    }

    #endregion


    #region Private Methods

    private void Init()
    {
        totalUnitsPrefabs = _unitsPrefabs.Length;
        _castleHealth = GetComponent<HealthComponent>();
        _isSwitchedToDamageSprite = false;
        _isCastleDestroyed = false;

        _coinsPerTurn = _startCoinsPerTurnValue;
        StartCoroutine(ReceiveCash());
    }


    private IEnumerator TEST_DeployUnitsWithDelay(float delay)
    {
        spawnUnit(UNIT_TYPE.KNIGHT);
        yield return new WaitForSeconds(delay);
        spawnUnit(UNIT_TYPE.ARCHER);
        yield return new WaitForSeconds(delay);
        StartCoroutine(TEST_DeployUnitsWithDelay(delay));
    }

    private IEnumerator ReceiveCash()
    {
        if(FactionName == "RED")
        {
            while (true)
            {
                GameManager.Instance.CurrentREDCoinValue += _coinsPerTurn;
                yield return new WaitForSeconds(_coinReceiveDelay);

                yield return null;
            }
        }
        else
        {
            while (true)
            {
                GameManager.Instance.CurrentBLUECoinValue += _coinsPerTurn;
                yield return new WaitForSeconds(_coinReceiveDelay);

                yield return null;
            }
        }

    }

    #endregion

    #region Public Methods

    public void spawnUnit(UNIT_TYPE unit_type)
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
                ArcherUnit comp2 = npc.GetComponent<ArcherUnit>();
                comp2.EnemyCastle = _enemyCastle;
                //Init stuff

                break;
        }

    }

    public void UpgradeCastle()
    {
        if(FactionName == "RED")
        {
            if(GameManager.Instance.ConsumeCoins(_castleUpgradeCost, "RED"))
            {
                //Upgrade RED castle
                _currentCastleLevel++;
                //Increase upgrade cost
                //Increase health
                //Increase coins per second
            }
        }
        else
        {
            if(GameManager.Instance.ConsumeCoins(_castleUpgradeCost, "BLUE"))
            {
                //Upgrade BLUE castle
                _currentCastleLevel++;
            }
        }
    }

    #endregion

}
