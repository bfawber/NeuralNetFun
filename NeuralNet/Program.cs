using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
	class Program
	{
		static void Main(string[] args)
		{
			XOR();
		}

		static void XOR()
		{
			Neuron input1 = new Neuron
			{
				Value = 1
			};

			Neuron input2= new Neuron
			{
				Value = 0
			};

			Neuron bias1 = new Neuron
			{
				Value = 1
			};

			Neuron bias2 = new Neuron
			{
				Value = 1
			};

			Neuron hidden1 = new Neuron
			{
				Inputs = new List<Connection>
				{
					new Connection { Weight = 5, FromNeuron = input1 },
					new Connection { Weight = -6, FromNeuron = input2 },
					new Connection { Weight = -3, FromNeuron = bias1 }
				}
			};

			Neuron hidden2 = new Neuron
			{
				Inputs = new List<Connection>
				{
					new Connection { Weight = -6, FromNeuron = input1 },
					new Connection { Weight = 6, FromNeuron = input2 },
					new Connection { Weight = -3, FromNeuron = bias1 }
				}
			};

			Neuron output = new Neuron
			{
				Inputs = new List<Connection>
				{
					new Connection { Weight = 10, FromNeuron = input1 },
					new Connection { Weight = 10, FromNeuron = input2 },
					new Connection { Weight = -5, FromNeuron = bias2 }
				}
			};

			NeuralNet nn = new NeuralNet
			{
				ActivationFunction = (value) =>
				{
					return (float)(1.0 / (1.0 + Math.Pow(Math.E, -value)));
				}
			};

			Console.WriteLine($"Output = {nn.Calculate(output)}");
			Console.ReadKey();
        }
	}
}
