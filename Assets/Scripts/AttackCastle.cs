using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCastle : Goal
{

    #region Private Variables

    private Castle _enemyCastle;
    private Unit _owner;

    private float _stopRadius;

    #endregion

    #region Callback

    public AttackCastle(Castle enemy, Unit unit)
    {
        _enemyCastle = enemy;
        _owner = unit;
        _stopRadius = unit.GetComponent<BoxCollider2D>().bounds.size.x / 2;
    }

    #endregion

    #region Public Methods

    public override void Execute()
    {
        if(Vector2.Distance(_owner.transform.position, _enemyCastle.transform.position) <= _owner.AttackRange + 1.5f)
        {
            //Attack
            if(_owner.CanAttack())
                _owner.AttackObject(_enemyCastle.gameObject);
        }
        else if(_owner.findEnemy() != null)
        {
            _owner.ChangeGoal(GOAL_TYPE.ATTACK_ENEMY);
        }
        else if(DebugUtils.FIND_ENEMY_STATUS == Unit.ALLY_FOUND)
        {
            //Wait
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
