﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ePrrodaja.Model
{
    public class Proizvodi
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string? StateMachine { get; set; }
    }
}
