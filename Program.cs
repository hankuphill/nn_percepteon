using System;
using System.Linq;
using static System.Console;

namespace Neural_network_final
{
	public static class Core
	{
		public class Neuron
		{
			public Neuron()
			{
				weight=new decimal[4] {0.5m,0.3m,0.4m,0.1m};
			}
			private decimal[] weight;
			
			public decimal output;
			
			public decimal processInputData(decimal[] input)
			{
				for(int i =0;i<input.Length;++i)
					output+=input[i]*weight[i];
				
				return output;
			}
			
			
			public decimal LastError {get; private set;}
			
			public decimal LearningRate {get; set;} = 0.00001m;
			
			public void train (decimal[] input, decimal ExpectedResult)
			{
				decimal ActualResult=0m;
				
				for (int i=0;i!=input.Length;++i)
				{
					ActualResult=input[i]*weight[i];
					LastError=ExpectedResult - ActualResult;
					decimal Correction= (LastError/ ActualResult)* LearningRate;
					weight[i]+=Correction;
					Correction=0;
				}
			}
		}
		public static void Main()
		{
			decimal price = 2205824m;
			
			decimal[] input = new decimal[4];
			
			input[0] =0.93m;
			input[1] =3.97m;
			input[2] =2.85m;
			input[3] =23266647621m;
			
			Neuron neuron = new Neuron();
			
			int i =0;
			do{
				i++;
				neuron.train(input,price);
				
				if(i%10000==0)
					WriteLine($"iteration:{i}\t\tError:\t\t{neuron.LastError}");
				
			}while (neuron.LastError>neuron.LearningRate || neuron.LastError< -neuron.LearningRate);
			
			WriteLine($"predicted price:\t{neuron.processInputData(input)}");
			//WriteLine($"{neuron.processInputData(50)} miles in {50}km");
		}
	}
}











