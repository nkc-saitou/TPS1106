using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;//移動速度
    public float limitDistance;

    public GameObject Bullet; //弾

    int enemyHP = 3;

    GameObject target;

    AudioSource BulletShot;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 Direction = target.transform.position - transform.position;
        float Distance = Direction.sqrMagnitude;//自身と対象との距離
        Direction = Direction.normalized; //距離要素を取り除く
        Direction.y = 0.0f;

        //LimitDistanceより近いので逃げる
        if (Distance <= limitDistance)
        {
            transform.position -= Direction * speed * Time.deltaTime;
        }

        //LimitDistanceより２倍遠いので近づく
        else if (Distance > limitDistance * 2)
        {
            transform.position += Direction * speed * Time.deltaTime;
        }

        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        targetRotation.x = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        if(enemyHP <= 0)
        {
            Score.score += 5;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Bullet")
        {
            enemyHP--;
        }
    }
}