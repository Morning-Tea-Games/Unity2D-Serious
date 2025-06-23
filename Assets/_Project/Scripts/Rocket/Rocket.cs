using System;
using System.Collections.Generic;
using System.Linq;
using ParameterSystem;

namespace Rocket
{
    public class Rocket
    {
        public readonly RocketPartSO[] Parts;

        public Rocket(RocketPartSO[] parts)
        {
            Parts = parts;
        }

        public Parameter[] CalculateParameters()
        {
            if (Parts.Any(p => p == null))
            {
                return null;
            }

            Dictionary<string, float> aggregated = new();

            foreach (var part in Parts)
            {
                foreach (var param in part.Parameters)
                {
                    if (aggregated.ContainsKey(param.Name))
                    {
                        aggregated[param.Name] += param.Value;
                    }
                    else
                    {
                        aggregated[param.Name] = param.Value;
                    }
                }
            }

            var result = new Parameter[aggregated.Count];
            int index = 0;

            foreach (var kvp in aggregated)
            {
                result[index] = new Parameter(kvp.Key, kvp.Value);
                index++;
            }

            return result;
        }
    }
}