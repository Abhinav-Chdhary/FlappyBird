using UnityEngine;

public class iSpawn : MonoBehaviour
{
    public GameObject pipe; //to get the whole game object of Prefab
    public float spawnRate = 1f; //to customize the frequency of spawns
    public float minHeight = -1f;
    public float maxHeight = 1f; //to customize difficulty level of obstacles

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawnner), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(spawnner));
    }
    private void spawnner()
    {
        GameObject pipes = Instantiate(pipe, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
