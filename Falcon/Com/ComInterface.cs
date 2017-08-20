using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSky.Com
{
    interface ComInterface
    {
        //bool Connect();
        void Close();
        //bool Send(byte[] bytes);
        void Subscribe(Action<byte[]> func);
        void Unsubscribe(Action<byte[]> func);
    }
}
