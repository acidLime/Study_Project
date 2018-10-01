using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    protected Character.CharacterType _characterType;
    protected float _lifeTime = 5.0f;
    protected float _moveSpeed = 1.0f;


    void Start()
    {
        Destroy(gameObject, _lifeTime);
        _moveSpeed = moveSpeed;
    }

    void Update()
    {
        Vector3 moveOffset = _moveSpeed * Vector3.forward;
        transform.position += ((transform.rotation * moveOffset) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Character characterCollider = other.gameObject.GetComponent<Character>();
        Debug.Log("총을 쏜 오브젝트: " + _characterType);
        if (null != characterCollider)
        {
            //총에 맞은 캐릭터가 자신의 적이면
            if (characterCollider.GetCharacterType() != _characterType)
            {
                //총알을 삭제
                Debug.Log("총에 맞은 오브젝트: " + characterCollider);
                Destroy(gameObject);
            }
        }
    }

    public void SetOwnerCharacterType(Character.CharacterType characterType)
    {
        _characterType = characterType;
    }
    
}
