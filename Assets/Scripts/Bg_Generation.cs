using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Generation : MonoBehaviour
{
    public GameObject[] availableScenes;
    private List<GameObject> currentScenes; 
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float choke;
    public int[] genQueue = new int[5];

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        StartCoroutine(GeneratorCheck());
        choke = 38.0f;
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateSceneIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }

    void addScenes(float lastSceneX)
    {
        int randomSceneIndex = Random.Range(0, availableScenes.Length);
        randomSceneIndex = checkList(randomSceneIndex);

        GameObject scene = (GameObject)Instantiate(availableScenes[randomSceneIndex]);
        scene.SetActive(true);

        Transform sky = scene.transform.Find("SkyDrop");
        float sceneWidth = sky.GetComponent<BoxCollider2D>().size.x * sky.localScale.x;

        float sceneCenter = lastSceneX + sceneWidth * 0.5f;

        scene.transform.position = new Vector3(sceneCenter, 0, 0);
        currentScenes.Add(scene);
    }

    private void GenerateSceneIfRequired()
    {
        List<GameObject> scenesToRemove = new List<GameObject>();
        bool addScene = true;
        float playerX = transform.position.x;
        float removeSceneX = playerX - choke;
        float addSceneX = playerX + choke;
        float lastSceneX = 0;
        foreach(var scene in currentScenes)
        {
            Transform sky = scene.transform.Find("SkyDrop");
            float sceneWidth = sky.GetComponent<BoxCollider2D>().size.x * sky.localScale.x;
            float sceneStartX = scene.transform.position.x - (sceneWidth * 0.5f);
            float sceneEndX = sceneStartX + sceneWidth;

            if (sceneStartX > addSceneX)
            {
                addScene = false;
            }

            if (sceneStartX < addSceneX)
            {
                scenesToRemove.Add(scene);
            }

            lastSceneX = Mathf.Max(lastSceneX, sceneEndX);
        }

        foreach (var scene in scenesToRemove)
        {
            currentScenes.Remove(scene);
            Destroy(scene);
        }

        if (addScene)
        {
            addScenes(lastSceneX);
        }
    }

    private int checkList(int rand)
    {
        int returnValue = rand;
        bool isIn = false;

        for(int i = 0; i > genQueue.Length; i++)
        {
            if(rand == genQueue[i])
            {
                isIn = true;
            }
        }

        if(isIn == true)
        {
            int randomSceneIndex = Random.Range(0, availableScenes.Length);
            returnValue = checkList(randomSceneIndex);
        }

        for (int i = genQueue.Length-1; i > 0; i--)
        {
            genQueue[i] = genQueue[i - 1];
        }
        genQueue[0] = returnValue;

        return returnValue;
    }
}
