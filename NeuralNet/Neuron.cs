using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
	public class Neuron
	{
		public IEnumerable<Connection> Inputs { get; set; }

		public float Value { get; set; }

		public Neuron() { }
	}

	public class Connection
	{
		public int Weight { get; set; }

		public Neuron Neuron { get; set; }
	}
}
