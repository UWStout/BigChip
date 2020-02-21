using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Generation : MonoBehaviour
{
    public GameObject[] availableScenes;
    public List<GameObject> currentScenes; 
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

    private void addScene()
    {

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
            addScene(lastSceneX);
        }
    }
}
