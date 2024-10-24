using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sleepTimer;
    [SerializeField] private Rigidbody _rigidbodyBullet;
    [SerializeField] private Transform _enemy;

    private WaitForSeconds _sleepTime;

    private void Awake()
    {
        _sleepTime = new WaitForSeconds(_sleepTimer);
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            Vector3 shootingVector = (_enemy.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_rigidbodyBullet, transform.position + shootingVector, Quaternion.identity);

            newBullet.transform.up = shootingVector;
            newBullet.velocity = shootingVector * _speed;

            yield return _sleepTime;
        }
    }
}