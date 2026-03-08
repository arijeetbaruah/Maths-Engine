using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Baruah.MathsEngine.Editor
{
    public class ComparisonOperatorDropdown : AdvancedDropdown
    {
        private Action<Type> _onSelect;
        private List<Type> _types;

        public ComparisonOperatorDropdown(AdvancedDropdownState state, Action<Type> onSelect)
            : base(state)
        {
            _onSelect = onSelect;
            minimumSize = new Vector2(250, 300);

            _types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract && typeof(ComparisonOperator).IsAssignableFrom(t))
                .ToList();
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new ComparisonOperatorItem("Math Nodes");

            foreach (var type in _types)
            {
                AddTypeToTree(root, type);
            }

            return root;
        }

        private void AddTypeToTree(ComparisonOperatorItem root, Type type)
        {
            string path = type.Name;

            string[] parts = path.Split('/');
            ComparisonOperatorItem parent = root;

            foreach (var part in parts)
            {
                var existing = parent.children?
                    .OfType<ComparisonOperatorItem>()
                    .FirstOrDefault(c => c.name == part);

                if (existing == null)
                {
                    existing = new ComparisonOperatorItem(part);
                    parent.AddChild(existing);
                }

                parent = existing;
            }

            parent.NodeType = type;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item is ComparisonOperatorItem typedItem && typedItem.NodeType != null)
            {
                _onSelect?.Invoke(typedItem.NodeType);
            }
        }
    }
    
    public class ComparisonOperatorItem : AdvancedDropdownItem
    {
        public Type NodeType;

        public ComparisonOperatorItem(string name, Type type = null) 
            : base(name)
        {
            NodeType = type;
        }
    }
}
