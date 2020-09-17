using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Keyboard
    {

        private Dictionary<int, bool> keys;
        public Keyboard()
        {
            keys = new Dictionary<int, bool>();
        }

        public void KeyUp(int keyValue)
        {
            if (!keys.ContainsKey(keyValue))
                keys.Add(keyValue, false);
            else
                keys[keyValue] = false;
        }
        public void KeyDown(int keyValue)
        {
            if (!keys.ContainsKey(keyValue))
                keys.Add(keyValue, true);
            else
                keys[keyValue] = true;
        }
        public bool IsKeyDown( int keyValue)
        {
            if (!keys.ContainsKey(keyValue))
                return false;
            else
                return keys[keyValue];
        }

        public bool IsKeysDown(params int[] keyValues)
        {
            foreach (var k in keyValues)
                if( !IsKeyDown(k))
                    return false;

            return true;
        }
    }
}
