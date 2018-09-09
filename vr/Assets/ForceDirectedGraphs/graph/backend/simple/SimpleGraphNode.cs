using System;

namespace AssemblyCSharp
{
	public class SimpleGraphNode : AbstractGraphNode
	{

		private SimpleGraphBackend graphBackend;
		private long id;
        private string name;
        private bool suburb;

		public SimpleGraphNode (SimpleGraphBackend simpleGraphBackend, long id, string name, bool suburb)
		{
			this.graphBackend = simpleGraphBackend;
			this.id = id;
            this.name = name;
            this.suburb = suburb;
		}

		public override void Accept (GraphEdgeVisitor graphEdgeVisitor)
		{
			graphBackend.FindEdges (id).ForEach (edge => {
				graphEdgeVisitor(edge);
			});
		}

		public override long GetDegree ()
		{
			return graphBackend.FindEdges (id).Count;
		}

		public override bool IsAdjacent (AbstractGraphNode graphNode)
		{
			return graphBackend.FindEdges (id, graphNode.GetId ()).Count > 0;
		}

		public override long GetId ()
		{
			return id;
		}
        public override string GetName()
        {
            return name;
        }
        public override bool GetSuburb()
        {
            return suburb;
        }
    }
}

