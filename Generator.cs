using UnityEngine;

public class Generator : MonoBehaviour
{
    public int spawnWidth;
    public int spawnHeight;
    [Space(20)]
    public GameObject blockPrefab;
    public GameObject goldBlockPrefab;
    [Range(0, 100)]
    public float goldSpawnChance;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnWidth; i++)
        {
            for (int j = 0; j < spawnHeight; j++)
            {
                Vector2 spawnPos = new Vector2(i, j);

                Instantiate(CreateBlock(), spawnPos, Quaternion.identity);
            }
        }
    }

    private GameObject CreateBlock()
    {
        var chance = UnityEngine.Random.Range(0f, 100f);
        if (chance < goldSpawnChance) return goldBlockPrefab;
        else return blockPrefab;
    }    
}
