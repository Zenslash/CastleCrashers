using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    #region Private Variables

    [SerializeField]
    private int _startHpValue = 100;
    [SerializeField]
    private float _deathDelay = 2f;

    private int _currentHpValue;
    private bool _isDeath = false;

    #endregion

    #region Public Variables

    public int CurrentHP
    {
        get { return _currentHpValue; }
    }

    public float CurrentHPAsPercent
    {
        get { return ((float)_currentHpValue * 100) / _startHpValue; }
    }

    public bool IsAlive
    {
        get { return !_isDeath; }
    }

    #endregion

    #region Callbacks

    private void Start()
    {
        _currentHpValue = _startHpValue;
    }

    private void Update()
    {
        if(!_isDeath && _currentHpValue <= 0)
        {
            _isDeath = true;
            StartCoroutine(UnitDeath());
        }
    }

    #endregion

    #region Private Methods

    private IEnumerator UnitDeath()
    {
        //Play death animation
        //Play death sound
        yield return new WaitForSeconds(_deathDelay);
        Destroy(gameObject);
    }

    #endregion

    #region Public Methods

    public void DealDamage(int value)
    {
        _currentHpValue = Mathf.Clamp(_currentHpValue - value, 0, _startHpValue);
    }

    #endregion

}
