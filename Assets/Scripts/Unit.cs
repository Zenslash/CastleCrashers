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
    [SerializeField]
    protected float _attackDelay = 1f;
    [SerializeField]
    protected float _stopRadius = 1.5f;

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


    public const int ENEMY_NOT_FOUND = 0;
    public const int ENEMY_FOUND = 1;
    public const int ALLY_FOUND = 2;

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

    protected virtual IEnumerator Attack(GameObject enemyObject)
    {
        yield return null;
    }

    #endregion

    #region Public Methods

    public void AttackObject(GameObject enemyObject)
    {
        StartCoroutine(Attack(enemyObject));
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
            DebugUtils.FIND_ENEMY_STATUS = ENEMY_FOUND;
            return collider.GetComponent<Unit>();
        }
        else if(collider != null)
        {
            Vector3 castleDir = EnemyCastle.transform.position - transform.position;
            castleDir.Normalize();
            collider = Physics2D.OverlapCircle(transform.position, _stopRadius);

            if ((collider.transform.position - transform.position).x * castleDir.x > 0)
                DebugUtils.FIND_ENEMY_STATUS = ALLY_FOUND;
            else
                DebugUtils.FIND_ENEMY_STATUS = ENEMY_NOT_FOUND;
        }
        else
        {
            DebugUtils.FIND_ENEMY_STATUS = ENEMY_NOT_FOUND;
        }


        return null;
    }

    #endregion


}
