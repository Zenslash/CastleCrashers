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
        _owner = unit;
    }

    #endregion

    #region Public Methods

    public override void Execute()
    {
        if(Vector2.Distance(_owner.transform.position, _enemyCastle.transform.position) <= _owner.AttackRange)
        {
            //Attack
            if(_owner.CanAttack())
                _owner.Attack(_enemyCastle.gameObject);
        }
        else if(_owner.findEnemy() != null)
        {
            _owner.ChangeGoal(GOAL_TYPE.ATTACK_ENEMY);
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
