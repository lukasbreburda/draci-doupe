using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracak
{
    class enemy
    {
        private string _name;
        private int _fig;
        private int _dev;
        private int _healt;
        private int _level;
        private string _lore;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int fig
        {
            get { return _fig; }
            set { _fig = value; }
        }
        public int dev
        {
            get { return _dev; }
            set { _dev = value; }
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
        public string lore
        {
            get { return _lore; }
            set { _lore = value; }
        }
        
       
        }

    
    }
