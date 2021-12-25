using System;
using UnityEngine;
using UnityEngine.Audio;

public class Block : MonoBehaviour
{
    [SerializeField] float durability;
    [SerializeField] Loot[] itemDrops;
    [SerializeField] AudioMixerGroup mixerGroup;

    [Header("Sounds")]
    public AudioClip breakSound;
    
    public void TakeDamage(float _damage)
    {
        durability -= _damage;
        if (durability <= 0) DestroyBlock();
    }

    private void DestroyBlock()
    {
        //audioSource.Play();
        SpawnLoot();

        //Spawn sound emmiter
        GameObject go = Instantiate(new GameObject());
        go.AddComponent<AudioSource>();
        go.GetComponent<AudioSource>().outputAudioMixerGroup = mixerGroup;
        go.GetComponent<AudioSource>().clip = breakSound;
        go.GetComponent<AudioSource>().Play();
        Destroy(go, 1f);

        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            for (int h = 0; h < itemDrops[i].amount; h++)
            {
                Instantiate(itemDrops[i].item, transform.position, Quaternion.identity);
            }
        }
    }
}

[Serializable]
public class Loot
{
    public GameObject item;
    public int amount;
}