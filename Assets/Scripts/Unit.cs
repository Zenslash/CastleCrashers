using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goal - based AI architecture

public class Unit : MonoBehaviour
{

    #region Private Variables


    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected float _attackRange;
    [SerializeField]
    protected int _attackDamage;

    protected Goal _currentGoal;
    protected string _enemyFaction;
    protected bool _isAttacking;
    protected HealthComponent _healthComponent;

    #endregion

    #region Public Variables

    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
    public float AttackRange
    {
        get { return _attackRange; }
    }

    public Castle EnemyCastle;

    #endregion

    #region Callbacks

    private void Start()
    {
        _currentGoal = new AttackCastle(EnemyCastle, this);
    }

    private void Update()
    {
        //Check another goals statements


        _currentGoal.Execute();
    }

    #endregion

    #region Private Methods



    #endregion

    #region Public Methods

    public virtual void Attack(GameObject enemyObject)
    {

    }

    public bool CanAttack()
    {
        return !_isAttacking;
    }

    public void ChangeGoal(GOAL_TYPE type)
    {
        if(type == GOAL_TYPE.ATTACK_CASTLE)
        {
            _currentGoal = new AttackCastle(EnemyCastle, this);
        }
        else
        {
            _currentGoal = new AttackNearestEnemy(findEnemy(), this);
        }
    }

    public Unit findEnemy()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, AttackRange);
        if (collider != null && collider.tag == _enemyFaction)
        {
            return collider.GetComponent<Unit>();
        }

        return null;
    }

    #endregion


}
