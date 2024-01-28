using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBook1._0
{
    public class GraphNode:StoryInformation
    {
        public GraphNode(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public string Story { get; set; }
        public string StepDescription { get; set; }
        public List<GraphNode> ChildNodes { get; } = new List<GraphNode>();

    }
}
