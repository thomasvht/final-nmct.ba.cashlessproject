﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.project.model.Model
{
    class RegistersCostumer
    {
        private int _id;

        public int  ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _device;

        public string Device
        {
            get { return _device; }
            set { _device = value; }
        }
        
    }
}
