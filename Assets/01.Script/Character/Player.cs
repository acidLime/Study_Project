using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    float _h;
    float _v;
    float _jumpPower = 10.0f;
    float _moveSpeed = 10.0f;

    protected override void InitCharacterType()
    {
        _characterType = CharacterType.PLAYER;
    }
    protected override void Shot()
    {
        //마우스 왼쪽 클릭시, 총알 생성
        Quaternion shotRotation = transform.rotation;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, shotRotation);
        }
           
    }
    protected override void Move()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        Vector3 position = new Vector3(_h,0,_v) * _moveSpeed * Time.deltaTime;
        transform.Translate(position);

    }
  
    protected override void Jump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        _isJumping = false;
    }
   

    float _rotationY = 0.0f;
    float _rateSpeed = 180.0f;
    float _addRotationY;

    //오일러 공식을 이용하여 플레이어 회전
    protected override void UpdateRotate()
    {
        _addRotationY = Input.GetAxis("Mouse X") * _rateSpeed;
        _rotationY += (_addRotationY * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, _rotationY, 0.0f);
    }
}
