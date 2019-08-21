﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ_W__algortihms
{
    class Utils
    {
        public static readonly int rowsInTLP = 5;
        public static readonly int columnsInTLP = 2;

        public enum AlgorithmName { LZ77, LZ78, LZW }
        public enum ParameterType { Text, List}
        public struct AlgorithmParameter
        {
            string paramName;
            string currValue;
            ParameterType pt;
            List<string> values;


            public AlgorithmParameter(string name, string defaultVal, ParameterType pt = ParameterType.Text, List<string> values = null)
            {
                paramName = name;
                currValue = defaultVal;
                this.pt = pt;
                this.values = values;
            }

            public string ParamName { get => paramName; set => paramName = value; }
            public string CurrValue { get => currValue; set => currValue = value; }
            public ParameterType PT { get => pt; set => pt = value; }
            public List<string> Values { get => values; set => values = value; }
        }

        public struct AlgorithmStatistic
        {
            string statisticName;
            string statisticValue;

            public AlgorithmStatistic(string name, string value)
            {
                statisticName = name;
                statisticValue = value;
            }

            public string StatisticName { get => statisticName; set => statisticName = value; }
            public string StatisticValue { get => statisticValue; set => statisticValue = value; }
        }

        public struct StepInfo
        {
            int from;
            int to;
            int[] mask;
            char color;
            public int From { get => from; set => from = value; }
            public int To { get => to; set => to = value; }
            public int[] Mask { get => mask; set => mask = value; }
            public char Color { get => color; set => color = value; }

            public StepInfo(int from, int to, int[] mask, char color)
            {
                this.from = from;
                this.to = to;
                this.mask = mask;
                this.color = color;
            }

        }

    }
}
