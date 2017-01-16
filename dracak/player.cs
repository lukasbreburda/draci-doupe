using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracak
{
    class player
    {
        private string _name;
        private int _fight;
        private int _def;
        private int _healt;
        private int _level;

        public string name
        {
            get { return _name;  }
            set { _name = value; }
        }
        public int fight               
        {
            get { return _fight; }
            set { _fight = value; }
        }
        public int dev
        {
            get { return _def; }
            set { _def = value; }
        }
        public int healt
        {
            get { return _healt; }
            set { _healt = value; }
        }
        public int level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}
