using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
	public class Neuron
	{
		public List<Connection> Inputs { get; set; }

		public List<Connection> Outputs { get; set; }

		public float Value { get; set; }

		public Neuron() { }
	}

	public static class NeuronFactory
	{
		public static Neuron Create(float value, List<Connection> inputs = null, List<Connection> outputs = null)
		{
			return new Neuron
			{
				Inputs = inputs == null ? new List<Connection>() : inputs,
				Outputs = outputs == null ? new List<Connection>() : outputs,
				Value = value
			};
		}
	}

	public class Connection
	{
		public float Weight { get; set; }

		public Neuron FromNeuron { get; set; }

		public Neuron ToNeuron { get; set; }
	}
}
