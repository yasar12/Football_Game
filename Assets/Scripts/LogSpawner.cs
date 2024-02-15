using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] GameObject log1;
    [SerializeField] GameObject log2;
    // Start is called before the first frame update
    void Start()
    {
        log1.SetActive(false);
        log2.SetActive(false);
        StartCoroutine(SpawnLog());
       //FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnLog()
    {
        log1.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        log2.SetActive(true);
        yield return null;
    }
}
