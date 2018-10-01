using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public GameObject bullet;
    protected Rigidbody _rigid;
    protected bool _isJumping = false;

    //캐릭터의 타입을 나눔
    public enum CharacterType
    {
        PLAYER,
        ENEMY
    }
    protected CharacterType _characterType;

    void Start()
    {
        InitCharacterType();
        _rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Shot();
        Move();
        UpdateRotate();
        JumpCheck();
    }

    //캐릭터의 타입을 설정
    virtual protected void InitCharacterType()
    {
        _characterType = CharacterType.PLAYER;
    }

    public CharacterType GetCharacterType()
    {
        return _characterType;
    }
    virtual protected void Shot()
    {

    }
    virtual protected void Move()
    {
       
    }
    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
        }
        if (_isJumping)
        {
            Jump();
        }
    }
    virtual protected void Jump()
    {

    }
    virtual protected void UpdateRotate()
    {

    }
}
