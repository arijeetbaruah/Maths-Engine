using System.Collections.Generic;
using Baruah.MathsEngine.Core;
#if ODIN_INSPECTOR
using System.Linq;
using Baruah.MathsEngine.Attribute;
using Sirenix.Utilities;
#if UNITY_EDITOR
using System;
using Sirenix.OdinInspector.Editor;
#endif
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    public abstract class ArithmeticBase : BaseMathNode
    {
        /// <summary>
        /// The nodes whose results will be added together.
        /// </summary>
        [SerializeReference, SerializeField]
#if ODIN_INSPECTOR
        [ListDrawerSettings(HideAddButton = true)]
#endif
        protected List<BaseMathNode> _values = new ();

#if ODIN_INSPECTOR
        [Button("Add Node", Style = ButtonStyle.Box)]
        private void AddNode()
        {
#if UNITY_EDITOR
            string GetCateoryNames(Type type)
            {
                string path = type.Name;
                var category = type.GetCustomAttributes(typeof(MathNodeCategoryAttribute), false)
                    .FirstOrDefault() as MathNodeCategoryAttribute;

                if (category != null)
                    path = category.Category + "/" + type.Name;

                return path;
            }
            
            var types = UnityEditor.TypeCache.GetTypesDerivedFrom<BaseMathNode>()
                .Where(t => !t.IsAbstract);

            var selector = new GenericSelector<Type>(
                "Select Math Node",
                false,
                t => GetCateoryNames(t),
                types
            );

            selector.SelectionConfirmed += selection =>
            {
                var type = selection.FirstOrDefault();
                if (type == null) return;

                var node = ScriptableObject.CreateInstance(type) as BaseMathNode;

                _values.Add(node);

                GUI.changed = true;
            };

            selector.ShowInPopup();
#endif
        }
#endif
    }
}
