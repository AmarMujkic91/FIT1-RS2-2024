﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ePrrodaja.Model.Request
{
    public class ProizvodiUpdateRequest
    {
        public string? Naziv { get; set; }

        public decimal Cijena { get; set; }

        public int VrstaId { get; set; }

        public int JedinicaMjereId { get; set; }
    }
}
