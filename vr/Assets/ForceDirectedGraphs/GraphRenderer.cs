using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class GraphRenderer : MonoBehaviour {
	public GraphScenePrefabs graphScenePrefabs;
	public Camera cam;

	private Graph graph;
	private GraphScene graphScene;
    private bool shouldUpdate;
	void Start()
	{
        shouldUpdate = true;
		graph = new Graph (InitializeGraphBackend ());
		graphScene = new GraphScene (graph, graphScenePrefabs);

		GenerateTestData ();

		graphScene.DrawGraph ();
        StartCoroutine(Begin());
    }
    IEnumerator Begin()
    {
        // Disable all Updating of nodes after 15 second sorting for maximum VR performance
        // Times this to finish at end of load. Progress bar would be perfect but not enough time to deliver this...
        yield return new WaitForSeconds(30);
        shouldUpdate = false;
    }
    private AbstractGraphBackend InitializeGraphBackend()
	{
		return new SimpleGraphBackend ();
	}

	private void GenerateTestData()
	{
        new ExponentialGraphGenerator ().GenerateGraph (graph);
    }

	void Update ()
	{
        if (shouldUpdate == true)
        {
            graphScene.Update(2);
        }
	}
}
