using System;

namespace AssemblyCSharp
{
	public class SimpleGraphEdge : AbstractGraphEdge
	{

		private long id;
		private AbstractGraphNode startNode;
		private AbstractGraphNode endNode;
        private string name;
        private bool suburb;

		public SimpleGraphEdge (long id, string name, AbstractGraphNode startNode, AbstractGraphNode endNode)
		{
			this.id = id;
			this.startNode = startNode;
			this.endNode = endNode;
            this.name = name;
		}

		public override AbstractGraphNode GetStartGraphNode ()
		{
			return startNode;
		}

		public override AbstractGraphNode GetEndGraphNode ()
		{
			return endNode;
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

