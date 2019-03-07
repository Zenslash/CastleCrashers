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

    protected Goal _currentGoal;

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

    public virtual void Attack()
    {

    }

    #endregion


}
