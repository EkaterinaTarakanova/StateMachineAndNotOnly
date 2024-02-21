using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    [SerializeField] private float timeDelay;
    [SerializeField] private Vector2 minPositionSpawn;
    [SerializeField] private Vector2 maxPositionSpawn;
    private GameObject spawnedSprite;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(TeleportCoroutine());    
    }

    private IEnumerator TeleportCoroutine() 
    {
        while (true) 
        {
            TeleportSprite();
            PlaySound();
            yield return new WaitForSeconds(timeDelay);
            
        }
    }

    private void TeleportSprite()
    {
        float x = Random.Range(minPositionSpawn.x, maxPositionSpawn.x);
        float y = Random.Range(minPositionSpawn.y, maxPositionSpawn.y);
        var spawnPosition = new Vector3(x, y, 0);
        sprite.transform.position = spawnPosition;
    }

    private void PlaySound() 
    {
        audioSource.Play();
    }
}
