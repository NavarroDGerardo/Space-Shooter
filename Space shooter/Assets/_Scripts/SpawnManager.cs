using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(meteorCreation());
        StartCoroutine(enemyCreation());
    }

    // Update is called once per frame
    public IEnumerator meteorCreation()
    {
        while (true)
        {
            Instantiate(meteorPrefab, new Vector3(7, Random.Range(-3.4f, 3f), 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    public IEnumerator enemyCreation()
    {
        while (true)
        {
            Instantiate(enemyShip, new Vector3(7, Random.Range(-3.4f, 3f), 0), Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(5.0f);
        }
    }
}
