using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNearestEnemy : Goal
{

    #region Private variables

    private Unit _enemyUnit;
    private Unit _owner;

    #endregion

    #region Public Variables
    #endregion

    #region Callbacks

    public AttackNearestEnemy(Unit enemy, Unit owner)
    {
        _enemyUnit = enemy;
        _owner = owner;
    }

    #endregion

    #region Private methods
    #endregion

    #region Public methods

    public override void Execute()
    {
        if(_enemyUnit != null)
        {
            _owner.Attack(_enemyUnit.gameObject);
        }
        else
        {
            _owner.ChangeGoal(GOAL_TYPE.ATTACK_CASTLE);
        }
    }

    #endregion

}
