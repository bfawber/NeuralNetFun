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

		public IEnumerable<float> Calculate()
		{
			return Net[Net.Count - 1].Select(n => Calculate(n));
		}

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
			if (layer > Net.Count)
			{
				throw new IndexOutOfRangeException();
			}
			else if(layer == Net.Count)
			{
				Net.Add(new List<Neuron> { neuron });
			}
			else
			{
				if (Net[layer] == null)
				{
					Net[layer] = new List<Neuron> { neuron };
				}
				else
				{
					Net[layer].Add(neuron);
				}
			}
		}

		public void ConnectNeurons(int fromLayer, int fromLocation, int toLayer, int toLocation, float weight)
		{
			Connection toConnection = new Connection
			{
				ToNeuron = Net[toLayer][toLocation],
				Weight = weight
			};

			Net[fromLayer][fromLocation].Outputs.Add(toConnection);

			Connection fromConnection = new Connection
			{
				FromNeuron = Net[fromLayer][fromLocation],
				Weight = weight
			};

			Net[toLayer][toLocation].Inputs.Add(fromConnection);
		}

		public void ConnectLayersCompletelyWithRandomWeights()
		{
			Random rand = new Random();

			for(int i = 0; i < Net.Count - 1; i++)
			{
				for(int j = 0; j < Net[i].Count; j++)
				{
					for (int z = 0; z < Net[i + 1].Count; i++)
					{
						ConnectNeurons(i, j, i + 1, z, rand.Next());
					}
				}
			}
		}
	}
}
