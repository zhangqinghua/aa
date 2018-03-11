using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject pinPrefab;
    public AudioSource shotAudio;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shotAudio.Play();
            SpawnPin();
        }
    }

    private void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }

}
