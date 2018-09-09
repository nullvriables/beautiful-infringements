using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class ExponentialGraphGenerator : AbstractGraphGenerator
	{
		public override void GenerateGraph (Graph graph)
		{
            AbstractGraphNode Canberra = graph.NewNode(false); // root node
            List<Dictionary<string, object>> cameraFinesdata = CSVReader.Read("cameraFines");
            for (var i = 0; i < cameraFinesdata.Count; i++)
            {
                CreateSuburb(graph, Canberra, (int)cameraFinesdata[i]["id"]);
            }
        }
        void CreateSuburb(Graph graph, AbstractGraphNode Canberra, int numFines)
        {
            AbstractGraphNode Suburb = graph.NewNode(true);
            graph.NewEdge(Canberra, Suburb);
            graph.NewEdge(Suburb, Canberra);
            GenerateDescedants(3, graph, Suburb, numFines);
        }

		void GenerateDescedants (int level, Graph graph, AbstractGraphNode startNode, int numNodes)
		{
			for (int index = 0; index < numNodes; index++) {
				AbstractGraphNode descedantNode = graph.NewNode (false);
				graph.NewEdge (startNode, descedantNode);
                graph.NewEdge(descedantNode, startNode);
            }
		}
    }
}

