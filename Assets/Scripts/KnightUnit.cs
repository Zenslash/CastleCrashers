using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightUnit : Unit
{

    #region Private Variables
    #endregion

    #region Public Variables
    #endregion

    #region Callbacks

    private void Start()
    {
        _enemyFaction = EnemyCastle.FactionName;
        _healthComponent = GetComponent<HealthComponent>();
        _currentGoal = new AttackCastle(EnemyCastle, this);
    }

    private void Update()
    {
        if(_healthComponent.IsAlive)
            _currentGoal.Execute();
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    public override void Attack(GameObject enemyObject)
    {
        _isAttacking = true;

        //Play animation
        //Play sound
        //Get Health component
        HealthComponent enemyHealth = enemyObject.GetComponent<HealthComponent>();
        //Deal damage
        if(enemyHealth != null)
        {
            enemyHealth.DealDamage(_attackDamage);
        }

        _isAttacking = false;
    }

    #endregion

}
