﻿using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos.Interfaces
{
    public interface IArticulo
    {
        List<Articulos> GetAllArticulos();
    }
}
