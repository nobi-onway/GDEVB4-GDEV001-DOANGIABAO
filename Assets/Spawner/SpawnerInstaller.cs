using UnityEngine;

public class SpawnerInstaller : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _boundX = 5f;
    [SerializeField] private float _boundY = 5f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-_boundX, _boundX), Random.Range(-_boundY, _boundY));
        Instantiate(_prefab, spawnPosition, Quaternion.identity);
    }
}