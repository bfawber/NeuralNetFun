using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
	public class NeuralNet
	{
		public float Calculate(Neuron neuron)
		{
			if(neuron.Inputs == null || !neuron.Inputs.Any())
			{
				return neuron.Value;
			}

			float result = 0;

			foreach(Connection connection in neuron.Inputs)
			{
				float value = Calculate(connection.Neuron);
				result += value * connection.Weight;
			}

			return ActivationFunction.Invoke(result);
		}

		public Func<float, float> ActivationFunction { get; set; }
	}
}
