using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    class DoubleStackHistoryBuffer
    {
        enum Direction
        {
            NONE,
            FORWARD,
            BACKWARD
        }

        Direction direction = Direction.NONE;

        AccesibleStack<string> forwardStack = new AccesibleStack<string>();
        AccesibleStack<string> backwardStack = new AccesibleStack<string>();

        private int maxSize = 0;

        public DoubleStackHistoryBuffer(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void ResetNavigation()
        {
            string s = "";
            while (GetHistoryForward(ref s)){ }
            direction = Direction.NONE;
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
                if (backwardStack.Count() == 1)
                    backwardStack.Pop();
                if (backwardStack.Count() >= 2)
                {
                    backwardStack.RemoveBottom();
                }
            }
            backwardStack.Push(item);
        }

        public bool GetHistoryBackward(ref string historyItem)
        {
            if (backwardStack.Count() > 0)
            {
                string bwItem = "";
                bwItem = backwardStack.Pop();
                forwardStack.Push(bwItem);

                // change in direction: pop again so that
                // return will not be the last element the 
                // user already got
                if (direction == Direction.FORWARD)
                {
                    if (backwardStack.Count() > 0)
                    {
                        bwItem = backwardStack.Pop();
                        forwardStack.Push(bwItem);
                    }
                }
        
                historyItem = bwItem;
                direction = Direction.BACKWARD;
                return true;
            }
            return false;
        }

        public bool GetHistoryForward(ref string historyItem)
        {
            if (forwardStack.Count() > 0)
            {
                string fwItem = "";
                fwItem = forwardStack.Pop();
                backwardStack.Push(fwItem);

                // change in direction: pop again so that
                // return will not be the last element the 
                // user already got
                if (direction == Direction.BACKWARD)
                {
                    if (forwardStack.Count() > 0)
                    {
                        fwItem = forwardStack.Pop();
                        backwardStack.Push(fwItem);

                    }
                }
              
                historyItem = fwItem;
                direction = Direction.FORWARD;

                return true;

            }
            return false;
        }

        public int CountItems()
        {
            return backwardStack.Count() + forwardStack.Count();
        }
    }
}
