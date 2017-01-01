using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
	public class NeuralNet
	{
		List<List<Neuron>> Net;

		public float Calculate(Neuron neuron)
		{
			if(neuron.Inputs == null || !neuron.Inputs.Any())
			{
				return neuron.Value;
			}

			float result = 0;

			foreach(Connection connection in neuron.Inputs)
			{
				float value = Calculate(connection.FromNeuron);
				result += value * connection.Weight;
			}

			return ActivationFunction.Invoke(result);
		}

		public Func<float, float> ActivationFunction { get; set; }

		public NeuralNet()
		{
			Net = new List<List<Neuron>>();
		}

		public void PushLayer(List<Neuron> layer)
		{
			Net.Add(layer);
		}

		public void PushLayer(IEnumerable<float> layerValues)
		{
			List<Neuron> layer = new List<Neuron>();
			foreach (float value in layerValues)
			{
				layer.Add(NeuronFactory.Create(value));
			}

			PushLayer(layer);
		}

		public void AddNeuron(int layer, Neuron neuron)
		{
			if(Net.Count > layer)
			{
				if(Net[layer] == null)
				{
					Net[layer] = new List<Neuron> { neuron };
				}
				else
				{
					Net[layer].Add(neuron);
				}
			}
		}
	}
}
