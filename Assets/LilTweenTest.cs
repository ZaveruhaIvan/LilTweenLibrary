#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using LilTween.Core;
using UnityEditor;
using UnityEngine;

namespace Tests
{
    public static class LilTweenTest
    {
        private static string Passed => "<color=green>[PASSED]</color>";
        private static string Failed => "<color=red>[FAILED]</color>";

        [MenuItem("Window/LilTween/Run test %#q")] // %#t = Ctrl/Cmd + Shift + T
        public static void RunTest()
        {
            var instances = CreateInstancesOfSubclasses<Tween>();
            var sb = new StringBuilder();
            sb.AppendLine("Test name");

            foreach (var instance in instances)
            {
                var className = instance.GetType().Name;
                var tweenTypeName = instance.TweenType.ToString();
                var text = className.Contains(tweenTypeName) ? $"Class: [{className}] {Passed}" : $"Class: [{className}] didn't same as type: [{tweenTypeName}] {Failed}";
                sb.AppendLine($"   * {text}");
            }

            Debug.Log(sb.ToString());
        }

        private static List<T> CreateInstancesOfSubclasses<T>() where T : class
        {
            var baseType = typeof(T);
            var types = Assembly.GetAssembly(baseType)
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(baseType));

            var list = new List<T>();
            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is T instance)
                {
                    list.Add(instance);
                }
            }

            return list;
        }
    }
}

#endif