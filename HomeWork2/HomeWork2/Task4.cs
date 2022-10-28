using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Tensor
    {
        private double[] variable;
        public int[] Shape { get; set; }
        
        public int Elements
        {
            get => Shape.Aggregate((a, b) => a * b);
        }

        public Tensor(params int[] shape)
        {
            Shape = shape;
            variable = new double[Elements];
        }

        public void Load(params double[] data) 
            => variable = data;

        public void Fill(double value)
        {
            for (int i = 0; i < Elements; i++)
                variable[i] = value;
        }

        public double this[params int[] indices]
        {
            get
            {
                var strides = GetContiguousStride();
                long index = 0;
                for (int i = 0; i < indices.Length; ++i)
                {
                    index += indices[i] * strides[i];
                }
                 return variable[index];
            }
            set
            {
                var strides = GetContiguousStride();
                long index = 0;
                for (int i = 0; i < indices.Length; ++i)
                {
                    index += indices[i] * strides[i];
                }
                variable[index] = value;
            }
        }
        public int[] GetContiguousStride()
        {
            int acc = 1;
            var stride = new int[Shape.Length];
            for (int i = Shape.Length - 1; i >= 0; --i)
            {
                stride[i] = acc;
                acc *= Shape[i];
            }
            return stride;
        }
        
        public void Print()
        {
            for (int i = 0; i < Shape[0]; i++)
            {
                if (Shape.Length > 1)
                {
                    for (int j = 0; j < Shape[1]; j++)
                    {
                        if (Shape.Length > 2)
                        {
                            for (int k = 0; k < Shape[2]; k++)
                            {
                                if (Shape.Length > 3)
                                {
                                    for (int g = 0; g < Shape[3]; g++)
                                    {
                                        Console.Write(this[k, g] + "  ");
                                    }
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.Write(this[j, k] + "  ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(this[i, j] + "  ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(this[i] + "  ");
                }
            }
        }
    }
}
