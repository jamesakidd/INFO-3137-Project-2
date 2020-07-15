﻿using System.Collections.Generic;

namespace DocumentBuilderLibrary
{
    public class JBuilder : IBuilder
    {
        private JBranch _root;
        private Stack<JBranch> _stack;

        //When creating a Composite, the builder should maintain a reference to the last opened
        // branch At Builder creation, this should be the root Branch

        public JBuilder()
        {
            _root = new JBranch();
            _stack = new Stack<JBranch>();
            _stack.Push(_root);
        }


        public void BuildBranch(string name)  //aka BuildComposite
        {
            JBranch node = new JBranch();
            _stack.Peek().AddChild(node);
            _stack.Push(node);
        }

        public void BuildLeaf(string name, string content)
        {
            JLeaf leaf = new JLeaf(name, content);
            _stack.Peek().AddChild(leaf);
        }

        public void CloseBranch()
        {
            _stack.Pop();
        }

        public IComposite GetDocument()
        {
            return _root;
        }
    }
}