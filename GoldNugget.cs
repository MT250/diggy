using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GoldNugget : MonoBehaviour
{
    [SerializeField] private int reward;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] AudioMixerGroup mixerGroup;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(reward);

            #if UNITY_EDITOR
            Debug.Log("Got nugget " + gameObject.GetInstanceID());
            #endif

            GameObject go = Instantiate(new GameObject());
            go.AddComponent<AudioSource>();
            go.GetComponent<AudioSource>().outputAudioMixerGroup = mixerGroup;
            go.GetComponent<AudioSource>().clip = pickupSound;
            go.GetComponent<AudioSource>().Play();
            Destroy(go, 1f);


            gameObject.SetActive(false);
        }
    }
}
