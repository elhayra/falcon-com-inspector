using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    class DoubleStackHistoryBuffer
    {
        Stack<string> forwardStack = new Stack<string>();
        Stack<string> backwardStack = new Stack<string>();

        private int maxSize = 0;

        public DoubleStackHistoryBuffer(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void ResetNavigation()
        {
            string s = "";
            while (GetHistoryForward(ref s)){ }
        }

        public void Clear()
        {
            forwardStack.Clear();
            backwardStack.Clear();
        }

        public void AddItem(string item)
        {
            if (CountItems() >= maxSize)
            {
                if (backwardStack.Count == 1)
                    backwardStack.Pop();
                if (backwardStack.Count >= 2)
                {
                    backwardStack.Reverse();
                    backwardStack.Pop();
                    backwardStack.Reverse();
                }
            }
            backwardStack.Push(item);
        }

        public bool GetHistoryBackward(ref string historyItem)
        {
            if (backwardStack.Count > 0)
            {
                string bwItem = backwardStack.Pop();
                forwardStack.Push(bwItem);
                historyItem = bwItem;
                return true;
            }
            return false;
        }

        public bool GetHistoryForward(ref string historyItem)
        {
            if (forwardStack.Count > 0)
            {
                string fwItem = forwardStack.Pop();
                backwardStack.Push(fwItem);
                historyItem = fwItem;
                return true;
            }
            return false;
        }

        public int CountItems()
        {
            return backwardStack.Count + forwardStack.Count;
        }
    }
}
