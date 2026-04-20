using UnityEngine;

public class SpawnerInstaller : MonoBehaviour
{
    [SerializeField] private GameObject _soldierPrefab;
    [SerializeField] private GameObject _dangerZonePrefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _dangerZoneSpawnInterval = 3f;
    [SerializeField] private float _boundX = 5f;
    [SerializeField] private float _boundY = 5f;

    private float _soldierTimer;
    private float _dangerZoneTimer;

    private void Update()
    {
        _soldierTimer += Time.deltaTime;
        _dangerZoneTimer += Time.deltaTime;

        if (_soldierTimer >= _spawnInterval)
        {
            SpawnSoldier();
            _soldierTimer = 0f;
        }

        if (_dangerZoneTimer >= _dangerZoneSpawnInterval)
        {
            SpawnDangerZone();
            _dangerZoneTimer = 0f;
        }
    }

    private void SpawnSoldier()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-_boundX, _boundX), Random.Range(-_boundY, _boundY));
        Instantiate(_soldierPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnDangerZone()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-_boundX, _boundX), Random.Range(-_boundY, _boundY));
        Instantiate(_dangerZonePrefab, spawnPosition, Quaternion.identity);
    }
}