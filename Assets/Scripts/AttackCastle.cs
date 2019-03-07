using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCastle : Goal
{

    #region Private Variables

    private Castle _enemyCastle;
    private Unit _owner;

    #endregion

    #region Callback

    public AttackCastle(Castle enemy, Unit unit)
    {
        _enemyCastle = enemy;
    }

    #endregion

    #region Public Methods

    public override void Execute()
    {
        if(Vector2.Distance(_owner.transform.position, _enemyCastle.transform.position) <= _owner.AttackRange)
        {
            //Attack
            _owner.Attack();
        }
        else
        {
            //Move
            Vector3 dir = _enemyCastle.transform.position - _owner.transform.position;
            dir.Normalize();

            _owner.transform.position += dir * _owner.MoveSpeed * Time.deltaTime;
        }
    }

    #endregion

}
