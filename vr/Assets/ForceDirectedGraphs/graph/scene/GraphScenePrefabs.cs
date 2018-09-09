using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class GraphScenePrefabs : MonoBehaviour
	{
        public GameObject RootPrefab;
        public GameObject SuburbPrefab;
        public GameObject NodePrefab;
        public GameObject EdgePrefab;

		public GameObject InstantiateNode(AbstractGraphNode nodePointer)
		{
            
            if (nodePointer.GetSuburb() == true)
            {
                GameObject node = Instantiate(SuburbPrefab);
                node.transform.SetParent(transform);
                return node;
            }
			else
            {
                if (nodePointer.GetId() == 0)
                {
                    GameObject node = Instantiate(RootPrefab);
                    node.transform.SetParent(transform);
                    return node;
                }
                else
                {
                    GameObject node = Instantiate(NodePrefab);
                    node.transform.SetParent(transform);
                    return node;
                }
            }
        }

		public GameObject InstantiateEdge()
		{
			GameObject edge = Instantiate (EdgePrefab);
			edge.transform.SetParent (transform);
			return edge;
		}
	}
}

