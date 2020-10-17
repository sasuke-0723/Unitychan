using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    //[SerializeField] float maxSpeed = 10;

    [SerializeField] float jump = 1;
    private bool _jump = false;
    private float jumpCount = 0;

    private Rigidbody _rigidbody;
    Vector3 force = Vector3.zero;

    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        float rotateX = Input.GetAxis("Horizontal2");
        float rotateZ = Input.GetAxis("Vertical2");

        // キャラクターの操作
        // 速度が 10 以下なら力を加える
        if (moveX != 0 || moveZ != 0)
        {
            if (_rigidbody.velocity.magnitude < 3)
            {
                force = new Vector3(moveX, 0, moveZ);
                _rigidbody.AddForce(force);
            }
        }

        // スティックが倒れている方向に向く
        if (rotateX != 0 || rotateZ != 0)
        {
            var direction = new Vector3(rotateX, 0, rotateZ);
            transform.localRotation = Quaternion.LookRotation(direction);
        }

        // 2回連続でジャンプ可能
        if (Input.GetButtonDown("PS4CrossButton") && _jump)
        {
            _rigidbody.velocity = Vector3.up * jump;
            jumpCount++;
            if (jumpCount >= 2)
            {
                _jump = false;
            }
        }
    }

    // 地面に着いたらジャンプの回数をリセット
    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
        jumpCount = 0;
    }
}
