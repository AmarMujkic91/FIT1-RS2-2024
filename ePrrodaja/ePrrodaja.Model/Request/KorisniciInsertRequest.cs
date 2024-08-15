﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ePrrodaja.Model.Request
{
    public class KorisniciInsertRequest
    {
        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string? Email { get; set; }

        public string? Telefon { get; set; }

        public string Lozinka { get; set; }

        public string LozinkaPotvrda { get; set; }

        public string KorisnickoIme { get; set; } = null!;

        public bool? Status { get; set; }
    }
}
