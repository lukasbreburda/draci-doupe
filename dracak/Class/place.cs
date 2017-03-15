using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracak
{
     public class place
    {
        private string _name;
        private int _fight_bonus;
        private int _dev_bonus;
        private string _lore;
        private string _image;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int fight_bonus
        {
            get { return _fight_bonus; }
            set { _fight_bonus = value; }
        }
        public int dev_bonus
        {
            get { return _dev_bonus; }
            set { _dev_bonus = value; }
        }
        public string lore
        {
            get { return _lore; }
            set { _lore = value; }
        }
        public string image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
