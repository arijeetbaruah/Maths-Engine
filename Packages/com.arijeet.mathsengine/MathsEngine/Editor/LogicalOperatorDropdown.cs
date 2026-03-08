using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Baruah.MathsEngine.Editor
{
    public class LogicalOperatorDropdown : AdvancedDropdown
    {
        private Action<Type> _onSelect;
        private List<Type> _types;

        public LogicalOperatorDropdown(AdvancedDropdownState state, Action<Type> onSelect)
            : base(state)
        {
            _onSelect = onSelect;
            minimumSize = new Vector2(250, 300);

            _types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract && typeof(LogicalOperator).IsAssignableFrom(t))
                .ToList();
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new LogicalOperatorDropdownItem("Logical Operator");
            root.AddChild(new LogicalOperatorDropdownItem("None"));

            foreach (var type in _types)
            {
                AddTypeToTree(root, type);
            }

            return root;
        }

        private void AddTypeToTree(LogicalOperatorDropdownItem root, Type type)
        {
            string path = type.Name;

            string[] parts = path.Split('/');
            LogicalOperatorDropdownItem parent = root;
            
            foreach (var part in parts)
            {
                var existing = parent.children?
                    .OfType<LogicalOperatorDropdownItem>()
                    .FirstOrDefault(c => c.name == part);

                if (existing == null)
                {
                    existing = new LogicalOperatorDropdownItem(part);
                    parent.AddChild(existing);
                }

                parent = existing;
            }

            parent.NodeType = type;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item is LogicalOperatorDropdownItem typedItem)
            {
                _onSelect?.Invoke(typedItem.NodeType);
            }
        }
    }
    
    public class LogicalOperatorDropdownItem : AdvancedDropdownItem
    {
        public Type NodeType;

        public LogicalOperatorDropdownItem(string name, Type type = null) 
            : base(name)
        {
            NodeType = type;
        }
    }
}
