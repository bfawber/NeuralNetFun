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
			XOR2();
		}

		static void XOR2()
		{
			NeuralNet nn = new NeuralNet
			{
				ActivationFunction = (value) =>
				{
					return (float)(1.0 / (1.0 + Math.Pow(Math.E, -value)));
				}
			};

			// inputs
			nn.AddNeuron(0, NeuronFactory.Create(1));
			nn.AddNeuron(0, NeuronFactory.Create(0));
			nn.AddNeuron(0, NeuronFactory.Create(1));

			// hidden layer 
			nn.AddNeuron(1, NeuronFactory.Create(-1));
			nn.AddNeuron(1, NeuronFactory.Create(-1));
			nn.AddNeuron(1, NeuronFactory.Create(1));

			// outputs
			nn.AddNeuron(2, NeuronFactory.Create(-1));

			// connections to h1
			nn.ConnectNeurons(0, 0, 1, 0, 5);
			nn.ConnectNeurons(0, 1, 1, 0, -6);
			nn.ConnectNeurons(0, 2, 1, 0, -3);

			// connections to h2
			nn.ConnectNeurons(0, 0, 1, 1, -6);
			nn.ConnectNeurons(0, 1, 1, 1, 6);
			nn.ConnectNeurons(0, 2, 1, 1, -3);

			// connections to output layer
			nn.ConnectNeurons(1, 0, 2, 0, 10);
			nn.ConnectNeurons(1, 1, 2, 0, 10);
			nn.ConnectNeurons(1, 2, 2, 0, -5);


			Console.WriteLine($"Output = {nn.Calculate().First()}");
			Console.ReadKey();
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
					new Connection { Weight = 10, FromNeuron = hidden1 },
					new Connection { Weight = 10, FromNeuron = hidden2 },
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
