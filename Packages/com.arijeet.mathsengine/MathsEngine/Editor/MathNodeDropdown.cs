using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Baruah.MathsEngine.Editor
{
    public class MathNodeDropdown : AdvancedDropdown
    {
        private Action<Type> _onSelect;
        private List<Type> _types;

        public MathNodeDropdown(AdvancedDropdownState state, Action<Type> onSelect)
            : base(state)
        {
            _onSelect = onSelect;
            minimumSize = new Vector2(250, 300);

            _types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract && typeof(BaseMathNode).IsAssignableFrom(t))
                .ToList();
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new MathNodeDropdownItem("Math Nodes");

            foreach (var type in _types)
            {
                AddTypeToTree(root, type);
            }

            return root;
        }

        private void AddTypeToTree(MathNodeDropdownItem root, Type type)
        {
            string path = type.Name;

            var category = type.GetCustomAttributes(typeof(MathNodeCategoryAttribute), false)
                .FirstOrDefault() as MathNodeCategoryAttribute;

            if (category != null)
                path = category.Path + "/" + type.Name;

            string[] parts = path.Split('/');
            MathNodeDropdownItem parent = root;

            foreach (var part in parts)
            {
                var existing = parent.children?
                    .OfType<MathNodeDropdownItem>()
                    .FirstOrDefault(c => c.name == part);

                if (existing == null)
                {
                    existing = new MathNodeDropdownItem(part);
                    parent.AddChild(existing);
                }

                parent = existing;
            }

            parent.NodeType = type;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item is MathNodeDropdownItem typedItem && typedItem.NodeType != null)
            {
                _onSelect?.Invoke(typedItem.NodeType);
            }
        }
    }
    
    public class MathNodeDropdownItem : AdvancedDropdownItem
    {
        public Type NodeType;

        public MathNodeDropdownItem(string name, Type type = null) 
            : base(name)
        {
            NodeType = type;
        }
    }
}
