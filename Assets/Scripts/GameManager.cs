using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Private Variables

    [SerializeField]
    private int _startCoinVal = 10;

    [SerializeField]
    private Text _coinLbl;


    private int _currentREDCoinValue;
    private int _currentBLUECoinValue;

    #endregion

    #region Public Variables

    public static GameManager Instance;

    public Castle RedCastle;


    public int CurrentREDCoinValue
    {
        get { return _currentREDCoinValue; }
        set
        {
            _currentREDCoinValue = value;
            _coinLbl.text = _currentREDCoinValue.ToString();
        }
    }

    public int CurrentBLUECoinValue
    {
        get { return _currentBLUECoinValue; }
        set
        {
            _currentBLUECoinValue = value;
        }
    }

    #endregion

    #region Callbacks

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        CurrentREDCoinValue = _startCoinVal;
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    //TODO Refactor method for both sides
    public bool ConsumeCoins(int value, string side)
    {
        if(side == "RED")
        {
            if (value <= _currentREDCoinValue)
            {
                CurrentREDCoinValue -= value;
                DebugUtils.BUY_STATUS = DebugUtils.BUY_SUCCEDED;
                return true;
            }
            else
            {
                DebugUtils.BUY_STATUS = DebugUtils.BUY_FAILED_NOT_ENOUGH_COINS;
                return false;
            }
        }
        else
        {
            if (value <= _currentBLUECoinValue)
            {
                CurrentBLUECoinValue -= value;
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    #endregion

}
