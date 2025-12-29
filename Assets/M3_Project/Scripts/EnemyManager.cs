using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemyController> _enemyList;
    [SerializeField] private EnemyController[] _enemyArr;
    [SerializeField] private int _maxEnemies;
    [SerializeField] private Vector2 _minSpawnPos, _maxSpawnPos;
    [SerializeField] private float _timerSpawn;
    [SerializeField] private float _difficultyChange;
    private float _timer;
    private float _timerDifficulty;

    public List<EnemyController> EnemyControllers { get => _enemyList; set => _enemyList = value; }

    public void AddEnemyToList(EnemyController enemy)
    {
        _enemyList.Add(enemy);
    }

    public void RemoveEnemyFromList(EnemyController enemy) 
    {
        _enemyList.Remove(enemy);
    }

    // Posizione e spawn casuale dei nemici
    public void SpawnRandomEnemy()
    {
        float _Xspawnpos = Random.Range(_minSpawnPos.x, _maxSpawnPos.x);
        float _Yspawnpos = Random.Range(_minSpawnPos.y, _maxSpawnPos.y);

        Vector2 _spawnPos = new Vector2(_Xspawnpos, _Yspawnpos);
        Instantiate(_enemyArr[Random.Range(0, _enemyArr.Length)], _spawnPos, Quaternion.identity);
    }

    private void Update()
    {
        // Aumento di difficolta' ogni _difficultyChange secondi (diminuisce l'intervallo di tempo tra gli spawn dei nemici e aumenta il numero massimo di nemici
        _timerDifficulty += Time.deltaTime;
        if(_timerDifficulty >= _difficultyChange && _timerSpawn != 1)
        {
            _timerSpawn--;
            _maxEnemies++;
            _timerDifficulty = 0;
        }
        // Spawn dei nemici ogni _timerSpawn secondi
        if (_enemyList.Count < _maxEnemies)
        {
            _timer += Time.deltaTime;
            if (_timer > _timerSpawn)
            {
                SpawnRandomEnemy();
                _timer = 0;
            }
        }
    }
}
