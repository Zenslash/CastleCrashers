using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBtn : MonoBehaviour
{

    #region Private Variables

    [SerializeField]
    private UNIT_TYPE _unitInSlot;
    [SerializeField]
    private int _unitCost;

    [Header("UI Properties")]
    [SerializeField]
    private Sprite _unitSprite;
    [SerializeField]
    private Text _costLbl;
    [SerializeField]
    private Image _unitImg;


    private Button _buyBtn;



    #endregion

    #region Public Variables
    #endregion

    #region Callbacks

    private void Start()
    {
        _buyBtn = GetComponent<Button>();

        _unitImg.sprite = _unitSprite;
        _costLbl.text = _unitCost.ToString();

        //Subscribe listener
        if(_buyBtn != null)
        {
            _buyBtn.onClick.AddListener(onBtnClick);
        }
    }

    #endregion

    #region Private Methods

    private void onBtnClick()
    {
        if(GameManager.Instance.ConsumeCoins(_unitCost, "RED"))
        {
            //Spawn unit
            GameManager.Instance.RedCastle.spawnUnit(_unitInSlot);
        }
    }

    #endregion

    #region Public Methods
    #endregion

}
