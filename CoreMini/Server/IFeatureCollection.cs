using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMini.Server
{
    public interface IFeatureCollection : IDictionary<Type, object>
    {
    }

    public class FeatureCollection : Dictionary<Type, object>, IFeatureCollection
    {
    }

    public static partial class Extensions
    {
        public static T Get<T>(this IFeatureCollection feature) => feature.TryGetValue(typeof(T), out var value) ? (T)value : default;

        public static IFeatureCollection Set<T>(this IFeatureCollection features, T feature)
        {
            features[typeof(T)] = feature;
            return features;
        }
    }
}
