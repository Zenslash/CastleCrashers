using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{

    #region Private Variables



    #endregion

    #region Public Variables

    public static MainCanvasManager Instance;

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

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    public Castle GetCastle(ref UnitBtn btn)
    {
        return null;
    }

    #endregion

}
