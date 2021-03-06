﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Engine
{
    public class InitializeDirectXEventArgs : EventArgs
    {
        public IDirectXProvider DirectX { get; private set; }
        public ISettings Settings { get; private set; }
        
        public InitializeDirectXEventArgs(IDirectXProvider directX, ISettings settings)
        {
            DirectX = directX;
            Settings = settings;
        }
    }
}
