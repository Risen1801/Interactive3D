using UnityEngine;


/// <summary>
/// Simple Tool to spawn objects in unity editor for performance testing
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject optimizedPrefabs;
    public GameObject notOptimizedPrefabs;

    public int numerOfInstances;

    public int numberOfInstancePerRow;

    public float distanceBetweenInstances;

    private GameObject prefabParent;



    [ContextMenu("Create Optimized Buildings")]
    public void CreateOptimizedBuildings()
    {
        CreateInstances(optimizedPrefabs);
    }

    [ContextMenu("Create Not Optimized Buildings")]
    public void CreateUnOptimizedBuildings()
    {
        CreateInstances(notOptimizedPrefabs);
    }

    [ContextMenu("Remove all Buildings")]
    public void RemoveAlldBuildings()
    {
        DestroyInstances();
    }

    private void CreateInstances(GameObject prefab)
    {
        DestroyInstances();

        float xPos = 0;
        float zPos = 0;

        prefabParent = new GameObject("Parent");
        //prefabParent.isStatic = true;

        for (int i = 1; i <= numerOfInstances; i++)
        {
            GameObject newGo = Instantiate(prefab, new Vector3(xPos, 0, zPos), prefab.transform.rotation, prefabParent.transform);
            //MarkAsStatic(newGo);

            xPos += distanceBetweenInstances;

            if (i % numberOfInstancePerRow == 0)
            {
                zPos += distanceBetweenInstances;
                xPos = 0;
            }
        }

        //StaticBatchingUtility.Combine(prefabParent);
    }

    private void DestroyInstances()
    {        
        DestroyImmediate(prefabParent);
        prefabParent = null;        
    }

    private void MarkAsStatic(GameObject gameObjectToStatic)
    {
        gameObjectToStatic.isStatic = true;

        int childCount = gameObjectToStatic.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gameObjectToStatic.transform.GetChild(i).gameObject.isStatic = true;
        }
    }
}
