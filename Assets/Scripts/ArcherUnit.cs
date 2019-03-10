using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUnit : Unit
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
        if (_healthComponent.IsAlive)
            _currentGoal.Execute();
    }

    #endregion

    #region Private Methods

    protected override IEnumerator Attack(GameObject enemyObject)
    {
        _isAttacking = true;

        //Play animation
        //Play sound
        //Get Health component
        HealthComponent enemyHealth = enemyObject.GetComponent<HealthComponent>();
        //Deal damage
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(_attackDamage);
        }

        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = false;
    }

    #endregion

    #region Public Methods
    #endregion

}
